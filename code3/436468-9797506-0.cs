    public class Foo
    {
        public delegate void Log(string s);
        public Log LoggingDelegate;
        public void DoWork() 
        { 
            LoggingDelegate("Working..."); 
        } 
    } 
    class Program
    {
        private static void Log( string s ) 
        { 
            Console.WriteLine(s); 
        } 
        static void Main(string[] args)
        {
            var myFoo = new Foo();
            myFoo.LoggingDelegate = Log;
            myFoo.DoWork(); 
        }
    }
