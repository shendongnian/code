    public void WriteValues(Func<double, double> f)
    {
        for (int i = 0; i <= 10; i++) {
            Console.WriteLine("f({0}) = {1}", i, f(i));
        }
    }
