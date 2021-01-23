    class Program
    {
        static void Main(string[] args)
        {
            Class1 cs = new Class1();
            cs.passIt();
            foreach (string s in cs.passArr)
            {
                Console.WriteLine("Inside main: " + s);
            }
            Console.ReadLine();
        }
    }
