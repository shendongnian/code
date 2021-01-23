    using System;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(Assembly.GetEntryAssembly().GetName().Name);
                Console.WriteLine(Application.ExecutablePath);
                Console.ReadLine();
            }
        }
    }
