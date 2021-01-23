    public class MyClass
    {
        private string _member = "foo";
        public string Member { get { return _member; } }
        public MyClass()
        {
            _member = "bar";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            Console.WriteLine(myClass.Member);
            Console.ReadLine();
        }
    }
