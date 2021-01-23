    using System;
    
    namespace InterfacesReferenceTypes
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass mc = new MyClass();
                DoThis(mc);
                Console.WriteLine(mc.Number);
                Console.ReadKey();
            }
    
            static void DoThis(IDemo id)
            {
                id.Number = 10;
            }
         }
        class MyClass : IDemo
        {
            //other props and methods etc
            public int Number { get; set; }
        }
        interface IDemo
        {
            int Number { get; set; }
        }
    }
