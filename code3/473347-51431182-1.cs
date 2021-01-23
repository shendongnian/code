    class Foo
    {
        public Foo(string s)
        {
            Console.WriteLine("inside foo");
            Console.WriteLine("foo" + s);
        }
    }
    class Bar : Foo
    {
        public Bar(string s) : base(((Func<string>)(delegate ()
        {
            Console.WriteLine("before foo");
            return "bar" + s;
        }))())
        {
            Console.WriteLine("inside bar");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Bar("baz");
        }
    }
