    static void Main(string[] args)
    {
        Foo j = new Foo(0);
        Func<Foo> f = () =>
        {
            Foo k = new Foo(j.N); // Can't just say k = j;
            for (int i = 0; i < 3; i++)
            {
                k.N += 1;
            }
            return k;
        };
        Console.WriteLine(f().N);
        Console.WriteLine(j.N);
        Console.Read();
    }
    public class Foo
    {
        public int N { get; set; }
        public Foo(int n) { N = n; }
    }
