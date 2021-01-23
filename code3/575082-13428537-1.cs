    public partial class Form2
    {
        public delegate void mydelegate(string some);
        public mydelegate mydelegateImpl = new mydelegate( arg => Console.WriteLine(arg) );
    }
