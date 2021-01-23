    IEnumerable<int> values = Enumerable.Range<int>(1, 10);
    Func<int, string> converter = i => i.ToString("0.00");
    // Variation 1, explicit calling
    IEnumerable<string> results1 = Extensions.Test<int, string>(values, converter);
    // Variation 2, explicit calling with type inference
    IEnumerable<string> results2 = Extensions.Test(values, converter);
    // Variation 3, extension method calling, still providing explicit types
    IEnumerable<string> results3 = values.Test<int, string>(values, converter);
    // Variation 4, extension method with type inference
    IEnumerable<string> results4 = values.Test(values, converter);
