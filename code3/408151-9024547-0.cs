    class Program
    {
        static void Main(string[] args)
        {
            using (System.Threading.Timer processTimer = new System.Threading.Timer(DoSomething, "fun", 0, 1000))
            {
                Console.ReadLine();
            }
        }
        static void DoSomething(object data)
        {
            Console.WriteLine("doing something {0}...", data.ToString());
        }
    }
