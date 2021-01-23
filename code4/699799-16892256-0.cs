    class KLAService : IKLAService
    {
        // Constructor injection
        public KLAService(ICentralLogic logic)
        {
            Console.WriteLine(logic.Value);
        }
    
        // Manual instance creation
        internal void PrintLogicValue()
        {
            var logic = ObjectFactory.Container.GetInstance<ICentralLogic>();
            Console.WriteLine(logic.Value);
        }
    }
    
    interface IKLAService
    {
    }
    
    class CentralLogic : ICentralLogic
    {
        public int Value { get; set; }
    
        public CentralLogic()
        {
            Value = 12345;
        }
    }
    
    interface ICentralLogic
    {
        int Value { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var logic = new CentralLogic();
    
            ObjectFactory.Initialize(x => x.Scan(scan => scan.TheCallingAssembly()));
            ObjectFactory.Container.Configure(x => x.For<ICentralLogic>().Use(y => logic));
    
            var service = ObjectFactory.Container.GetInstance<KLAService>();
            service.PrintLogicValue();
    
            Console.ReadKey();
        }
    }
