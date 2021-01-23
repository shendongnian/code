    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
    
            container.RegisterType(typeof(IEmployee), typeof(Employee));
    
            IEmployee emp = container.Resolve<IEmployee>();
    
            Console.ReadKey();
        }
    }
    
