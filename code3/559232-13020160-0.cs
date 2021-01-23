        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            foreach (string s in Directory.EnumerateFiles("../../images/"))
            {
                Console.WriteLine(s); 
            }
            Console.ReadLine(); // Just to keep the console from disappearing.
        }
