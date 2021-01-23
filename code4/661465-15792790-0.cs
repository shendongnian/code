    // common dll
    public interface IMyClass
    {
        string MyData { get; set; }
        IMyClass GetMyClass();
    }
    
    // dll1
    public class myClass : IMyClass
    {
        public string MyData { get; set; }
        public IMyClass GetMyClass() { return new myClass() { MyData = "abc" }; }
    }
    
    // dll2
    public class myClass2
    {
        public IMyClass GetMyClass()
        {
             var c1 = new myClass();
             var c2 = c1.GetMyClass();
             return c2;
        }
    }
    
    // exe (references common and dll2)
    public class Program
    {
        public static void Main(string[] args)
        {
            var c1 = new myClass2();
            IMyClass c2 = c1.GetMyClass();
            Console.Writeline(c2.MyData);
        }
    }
