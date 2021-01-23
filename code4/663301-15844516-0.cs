    public class Program
    {
        struct S
        {
            public int i;
        }
        static void Main(string[] args)
        {
            S s1 = new S();
            S s2 = s1;
            s1.i = 5;
            Console.WriteLine(s1.i);
            Console.WriteLine(s2.i);
        }
    }
