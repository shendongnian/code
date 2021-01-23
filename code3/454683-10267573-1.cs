    public class ServiceA : IServiceA
    {
        [Dependency]
        public IServiceB ServiceB { get; set; };
    
        public string MethodA1()
        {
            return "MethodA1() " +serviceB.MethodB1();
        }
    }
