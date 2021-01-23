    void Main() 
    {
        Console.WriteLine("Cast (reference): {0}", (TestEnum)5);
        Console.WriteLine("EnumConverter: {0}", EnumConverter<TestEnum>.Convert(5));
        Console.WriteLine("Enum.ToObject: {0}", Enum.ToObject(typeof(TestEnum), 5));
        
        int iterations = 1000 * 1000 * 100;
        Measure(iterations, "Cast (reference)", () => { var t = (TestEnum)5; });
        Measure(iterations, "EnumConverter", () => EnumConverter<TestEnum>.Convert(5));
        Measure(iterations, "Enum.ToObject", () => Enum.ToObject(typeof(TestEnum), 5));
    }
    
    static class EnumConverter<TEnum> where TEnum : struct, IConvertible
    {
        public static readonly Func<long, TEnum> Convert = GenerateConverter();
    
        static Func<long, TEnum> GenerateConverter()
        {
            var parameter = Expression.Parameter(typeof(long));
            var dynamicMethod = Expression.Lambda<Func<long, TEnum>>(
                Expression.Convert(parameter, typeof(TEnum)),
                parameter);
            return dynamicMethod.Compile();
        }
    }
    
    enum TestEnum 
    {
        Value = 5
    }
    
    static void Measure(int repetitions, string what, Action action)
    {
        action();
    
        var total = Stopwatch.StartNew();
        for (int i = 0; i < repetitions; i++)
        {
            action();
        }
        Console.WriteLine("{0}: {1}", what, total.Elapsed);
    }
