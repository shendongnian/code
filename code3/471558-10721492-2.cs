    abstract class BaseClass 
    { 
        public BaseClass() { } 
 
        protected string methodName; 
        protected int noOfTimes; 
        public void Execute(string MethodName, int NoOfTimes) 
        { 
            this.methodName = MethodName; 
            this.noOfTimes = NoOfTimes;
            doWork();
        } 
        protected abstract void doWork(); // will be provided by derived classes
    } 
 
    class DerivedClass : BaseClass 
    { 
        public DerivedClass() : base() { } 
 
        protected override void doWork()
        {
            Console.WriteLine("Running {0}, {1} times", this.methodName, this.noOfTimes); 
        } 
    } 
 
    public class Program   
    {   
        static void Main(string[] args) 
        { 
            DerivedClass d = new DerivedClass(); 
            d.Execute("Func", 2); 
 
            Console.ReadLine(); 
        } 
    }
