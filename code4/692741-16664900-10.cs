    using System.Text;
    
    namespace InterfacesRerefenceTypes
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass mc = new MyClass();
                Console.WriteLine(mc.Number);
                mc.val1 = 3;
                mc.val2 = 5;
                mc.Number = mc.val2;
                DoThis(mc);
                mc.val2 = mc.Number;
                
                Console.WriteLine(mc.val2);
                Console.ReadKey();
            }
    
            static void DoThis(IDemo id)
            {
                id.Number = 15;
            }
        }
    
        class MyClass : IDemo
        {
            public int val1 { get; set; }
            public int val2 { get; set; }
            public int Number { get; set; }
        }
    
        interface IDemo
        {
            int Number { get; set; }
        }
    }
