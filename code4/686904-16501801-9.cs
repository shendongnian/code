    public class FooService : IFooService, IBarService
    {
        public string FooMethod1()
        {
            return "FooMethod1";
        }
        public string FooMethod2()
        {
            return "FooMethod2";
        }
        public string BarMethod1()
        {
            return "BarMethod1";
        }
        public string BarMethod2()
        {
            return "BarMethod2";
        }
    }
