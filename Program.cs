using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio4
{
    class Program
    {
        static int cantidadHuerfanos = 0;
        static string consola = "";
        static char shutdown = 'Y';
        static int accion = 0;
        static List<informacion> datosNinos = new List<informacion>();
        static Boolean esNumero;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            while (shutdown.Equals('Y'))
            {
                bienvenida();//imprime bienvenida
                menu();// va a la acción menú 

                do
                {
                    esNumero = verificarNumeroOpcion();
                } while (!esNumero);
                

                switch (accion)
                {
                    case 1:
                        Console.Clear();
                        Boolean conocer = agregar();
                        if (conocer)
                        {
                            Console.Clear();
                            Console.WriteLine("\nSe agregó el registro correctamente");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nNo se agregó el registro, Intente de nuevo...");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Porcentaje de Casos Nacional y Casos en la capital ");

                        porcentajes();

                        break;
                    case 3:
                        Console.Clear();
                        grupos();
                        break;
                    case 4:
                        buscarRegistroPorID();
                        break;

                    default:
                        Console.WriteLine(">>>>> Ingrese opción válida ");
                        break;
                }

                //Console.Clear();
                accion = 0;

                shutdown = continuarPrograma();

            }

            Console.WriteLine("Desconectando del sistema....");
            Console.WriteLine("Todos los registros serán borrados....");
            Console.ReadKey();
        }

        static void bienvenida()
        {
            cantidadHuerfanos = datosNinos.Count;
            System.Console.Clear();
            Console.WriteLine("--------->>>>>> BIENVENIDOS AL SISTEMA UNICEF <<<<<<---------\n");
            Console.WriteLine("El sistema cuenta con " + cantidadHuerfanos + " niños/as registrados/as ");
            Console.WriteLine("Que acción desea realizar?");
        }

        static void menu()
        {
            Console.WriteLine("Ingrese el número de su selección ");
            Console.WriteLine("1) Ingresar registro ");
            Console.WriteLine("2) Cálculo por Departamento");
            Console.WriteLine("3) Cálculo por grupos ");
            Console.WriteLine("4) Buscar Registro por ID ");
        }

        static Boolean agregar()
        {
            Boolean valor = false;
            System.Console.Clear();
            informacion info = new informacion();
            informacion obtenerId = new informacion();
            try
            {
                Console.WriteLine("\nIngrese los datos del menor ");
                Console.WriteLine("\nIngrese nombre");
                info.nombre = Console.ReadLine();
                Console.WriteLine("\nIngrese sexo");
                info.sexo = sexos();
                Console.WriteLine("\nIngrese años cumplidos");
                
                info.edad = verificadorEdad();
                Console.WriteLine("\nIngrese orfanato");
                info.orfanato = Console.ReadLine();
                info.departamento = departamentos();
                obtenerId = datosNinos.LastOrDefault();
                int idD = 0;
                if (!cantidadHuerfanos.Equals(0)) { idD = obtenerId.id; }
                info.id = (idD + 1);
                datosNinos.Add(info);
                valor = true;
            }
            catch { }
            return valor;
        }

        public class informacion
        {
            public int id { get; set; }
            public String nombre { get; set; }
            public String sexo { get; set; }
            public int edad { get; set; }
            public String orfanato { get; set; }
            public String departamento { get; set; }
        }


        static String departamentos()
        {
            int posicion = 0;
            string[] depart = new string[14];
            depart[0] = "Santa Ana";
            depart[1] = "Ahuchanpán";
            depart[2] = "Sonsonate";
            depart[3] = "La Libertad";
            depart[4] = "Chalatenango";
            depart[5] = "San Salvador";
            depart[6] = "La Paz";
            depart[7] = "Cuscatlán";
            depart[8] = "Cabañas";
            depart[9] = "San Vicente";
            depart[10] = "Usulután";
            depart[11] = "San Miguel";
            depart[12] = "Morazán";
            depart[13] = "La Unión";
            Console.Clear();
            Console.WriteLine("Seleccione Código de departamento\n");
            for (int i = 0; i < depart.Length; i++)
            {
                int j = i + 1;
                Console.WriteLine(j + " " + depart[i]);
            }
            posicion = int.Parse(Console.ReadLine());
            posicion--;
            return depart[posicion];
        }

        static String sexos()
        {
            int posicion = 0;
            string[] sexos = new string[2];
            sexos[0] = "MASCULINO";
            sexos[1] = "FEMENINO";
            
            Console.Clear();
            Console.WriteLine("Seleccione Código de sexo\n");
            for (int i = 0; i < sexos.Length; i++)
            {
                int j = i + 1;
                Console.WriteLine(j + ") " + sexos[i]);
            }
            posicion = verificarNumeroGeneral();
            posicion--;
            return sexos[posicion];
        }


        static void porcentajes()
        {
            int contadorCapital = 0;
            int contadorPais = 0;
            double porcentajeCapital = 0.0;
            double porcentajePais = 0.0;
            for (int i = 0; i < datosNinos.Count; i++)
            {
                informacion datos = new informacion();
                datos = datosNinos[i];

                if (datos.departamento.Equals("San Salvador"))
                {
                    contadorCapital++;
                }
                contadorPais++;

            }

            porcentajeCapital = (contadorCapital * 100) / contadorPais;
            porcentajePais = 100 - porcentajeCapital;

            Console.WriteLine("Porcentaje Niños Capital " + porcentajeCapital + "%");
            Console.WriteLine("Porcentaje Niños del interior del país " + porcentajePais + "%");

        }

        static void grupos()
        {
            int grupo1 = 0, grupo2 = 0, grupo3 = 0, grupo4 = 0;
            for (int i = 0; i < datosNinos.Count; i++)
            {
                informacion datos = new informacion();
                datos = datosNinos[i];
                int anios = datos.edad;
                if (anios < 1)
                {
                    grupo1++;
                }
                else if (anios >= 1 && anios <= 3)
                {
                    grupo2++;
                }
                else if (anios >= 4 && anios <= 6)
                {
                    grupo3++;
                }
                else
                {
                    grupo4++;
                }
            }
            Console.Clear();
            Console.WriteLine("Grupo1: edad menor a 1 años --> " + grupo1);
            Console.WriteLine("Grupo 2: Edad comprendida entre 1 a 3 años --> " + grupo2);
            Console.WriteLine("Grupo 3: Edad comprendida entre 4 a 6 años --> " + grupo3);
            Console.WriteLine("Grupo 4: Edad mayor de 6 --> " + grupo4);

        }


        static Boolean verificarNumeroOpcion() {
            Boolean bol = false;
            Console.WriteLine("Ingrese opción");
            consola = Console.ReadLine();
            bol = int.TryParse(consola, out accion); /* Si es número correcto retornará true*/  

            return bol;
        }


        static int verificarNumeroGeneral()
        {
            Boolean bol = false;
            int eleccion = 0;
            do
            {
                 Console.WriteLine("Ingrese opción");
                consola = Console.ReadLine();
                bol = int.TryParse(consola, out eleccion); /* Si es número correcto retornará true*/
            } while (!bol);

            return eleccion;
        }

        static int verificadorEdad()
        {
            Boolean bol = false, bol2 = false;
            int age = -1;   
            do
            {
                Console.WriteLine("Ingrese edad de entre 0 y 17");
                consola = Console.ReadLine();
                bol = int.TryParse(consola, out age); /* Si es número correcto retornará true*/
                if (age >= 0 && age < 18) {
                    //bol2 = true;
                    if (bol2) { bol2 = true; }
                }
            } while (!bol && !bol2);
            
            return age;
        }


        static char continuarPrograma() {
            char  ver = 'Y';
            Boolean esValido = false;
            do
            {
                Console.Write("\nDesea ejecutar otra acción? Y/N ");
                consola = Console.ReadLine().ToUpper();
                esValido = char.TryParse(consola, out ver);
            }
            while (!esValido);

            return ver;
        }

        static void buscarRegistroPorID() {
            int id = 0;
            int tamanio = 0, verificar = 0;
            Console.Clear();
            Console.WriteLine("Existen "+ cantidadHuerfanos + " menores registrados en el sistema ");
            Console.WriteLine("Ingrese el ID del registro a buscar ");

            id = verificarNumeroGeneral();
            id = id - 1;
            informacion info = new informacion();

            tamanio = datosNinos.Count;

            if (id<=tamanio) 
            {
                info = datosNinos[id];
                verificar = info.id;

                if (!verificar.Equals(0))
                {
                    Console.WriteLine("Los datos del menor son ");
                    Console.WriteLine("ID --> " + info.id);
                    Console.WriteLine("Nombre --> " + info.nombre);
                    Console.WriteLine("Sexo --> " + info.sexo);
                    Console.WriteLine("Edad --> " + info.edad);
                    Console.WriteLine("Orfanato --> " + info.orfanato);
                    Console.WriteLine("Departamento --> " + info.departamento);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No se encontraron datos con ese ID");
                Console.WriteLine("Regresa el menú principal");
                Console.ReadKey();
            }



        }






        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
{
    new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
    new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
    new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
    new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
    new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
    new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
    new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
    new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
    new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
    new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
    new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
    new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
};
    }

}
