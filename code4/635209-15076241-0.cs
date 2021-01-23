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
                Program p = new Program();
    
                IA ia = p;
                ia.Display();
    
                IB ib = p;
                ib.Display();
            }
        }
