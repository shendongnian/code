    void Main()
    {
        var a = new EqualFilter<int> { Value = 10 };
        var b = new EqualFilter<double> { Value = 20 };
        b.Value = Math.PI; // RaiseFilteringChanged called - no surprise
        b.SetValue(Math.PI.ToString()); // RaiseFilteringChanged called - surprised?
        Console.WriteLine(b.Value);
        b.SetValue("25");
        Console.WriteLine(b.Value);
        var c = new EqualFilter<DateTime> { Value = DateTime.Today };
        Console.WriteLine(c.Value);
        c.SetValue("12/23/2011");
        Console.WriteLine(c.Value);
        // compiler error object isn't an IConvertible:
        // var illegal = new EqualFilter<object>();
    }
