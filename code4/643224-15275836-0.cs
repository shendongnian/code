    private class Closure
    {
        public int j;
        public int Method()
        {
            for (int i = 0; i < 3; i++)
            {
                this.j += i;
            }
            return this.j;
        }
    }
    static void Main(string[] args)
    {
        Closure closure = new Closure();
        closure.j = 0;
        Func<int> f = closure.Method;
        int myStr = f();
        Console.WriteLine(myStr);
        Console.WriteLine(closure.j);
        Console.Read();
    }
