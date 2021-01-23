    public class MyClass
    {
        public string this[string someArg]
        {
            get { return "You called this with " + someArg; }
        }
    
    }
    class Program
    {
    
        void Main()
        {
            MyClass x = new MyClass();
            Console.WriteLine(x["something"]);
        }
    }
