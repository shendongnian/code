    class Program
    {
        static void Main(string[] args)
        {
            InitMethod(new A() { Id = 100 });
            InitMethod(new B() { Name = "Test Name" });
            Console.ReadLine();
        }
        public static void InitMethod(object obj)
        {
            if (obj != null)
            {
                Console.WriteLine("Class {0}", obj.GetType().Name);
                foreach (var p in obj.GetType().GetProperties())
                {
                    Console.WriteLine("Property {0} type {1} value {2}", p.Name, p.GetValue(obj, null).GetType().Name, p.GetValue(obj, null));
                }
            }
        }
    }
