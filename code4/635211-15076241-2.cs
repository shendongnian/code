    interface IA
    {
       void Display();
    }
    interface IB
    {
       void Display();
    }
    
        public class Program:IA,IB
        {
    
            void IA.Display()
            {
                Console.WriteLine("I am from A");
            }
    
            void IB.Display()
            {
                Console.WriteLine("I am from B");
            }
    
            public static void Main(string[] args)
            {
               IA p1 = new Program();
               p1.Display();
               IB p2 = new Program();
               p2.Display();
            }
        }
