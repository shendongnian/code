    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("I'm going to open a form now!");
                var form = new Form1();
                form.ShowDialog();
            }
        }
    }
