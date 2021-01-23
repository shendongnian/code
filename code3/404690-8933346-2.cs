    public void Foo(IEnumerable<string> values)
    {
        double sum = 0;
        foreach (string x in values)
        {
            int z = x.Length;
            sum += z;
        }
        foreach (string x in values)
        {
            double z = double.Parse(x);
            sum += z;
        }
    }
