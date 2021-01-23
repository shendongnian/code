    static int Execute(int i) { return ((i / 63.53) == 34.23) ? -1 : (i * 2); }
    public static volatile int Result;
    private static void Main(string[] args)
    {
        const int iterations = 100000000;
        {
            Result = Execute(42);  // pre-jit
            var s = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                Result = Execute(i);
            }
            s.Stop();
            Console.WriteLine("Native: " + s.ElapsedMilliseconds);
        }
        {
            Func<int, int> func;
            using (var cscp = new CSharpCodeProvider())
            {
                var cp = new CompilerParameters { GenerateInMemory = true, CompilerOptions = @"/optimize" };
                string src = @"public static class Foo { public static int Execute(int i) { return ((i / 63.53) == 34.23) ? -1 : (i * 2); } }";
                var cr = cscp.CompileAssemblyFromSource(cp, src);
                var mi = cr.CompiledAssembly.GetType("Foo").GetMethod("Execute");
                func = (Func<int, int>)Delegate.CreateDelegate(typeof(Func<int, int>), mi);
            }
            Result = func(42);  // pre-jit
            var s = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                Result = func(i);
            }
            s.Stop();
            Console.WriteLine("Dynamic delegate: " + s.ElapsedMilliseconds);
        }
        {
            Func<int, int> func = Execute;
            Result = func(42);  // pre-jit
            var s = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                Result = func(i);
            }
            s.Stop();
            Console.WriteLine("Delegate: " + s.ElapsedMilliseconds);
        }
    }
