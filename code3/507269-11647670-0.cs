    class Program
    {
        static void Main(string[] args)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine(type.Name);
                MethodInfo[] mis = type.GetMethods();
                foreach (MethodInfo mi in mis)
                {
                    Console.WriteLine("\t" + mi.Name);
                }
            }
            Console.ReadLine();
        }
    }
