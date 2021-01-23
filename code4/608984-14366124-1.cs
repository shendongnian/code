    namespace Example
    {
        public class Program
        {
            Params p = new Params();
    
            string writefromParams()  // I exist just to give the string back from params with a nonstatic method
            {
                return p.key;
            }
    
            static void Main(string[] args)
            {
                Program p2 = new Program();  // set up a new instance of this very class
    
                Console.WriteLine(p2.writefromParams());  // get non static method from class
    
    
                Console.ReadLine();
            }
        }
    }
