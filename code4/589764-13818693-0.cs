    namespace ConsoleApplication1
    {
        interface IBase
        {
            void Referesh();
        }
        public class Base1 : IBase
        {
            public void Referesh()
            {
                Console.WriteLine("Hi"); 
            }
        }
        public class Class1 : Base1, IBase
        {
            public new void Referesh()
            {
                Console.WriteLine("Bye");
            }
    
        }
        class Program
        {
            static void Main(string[] args)
            {
                Class1 obj = new Class1();
                obj.Referesh();
    
                Console.ReadKey();
            }
        }
    }
