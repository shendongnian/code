    var methodInfos = new[] {
        // Static methods
        GetMethodInfo<int, int>(Math.Abs),
        GetMethodInfo<double, double>(Math.Abs),
        GetMethodInfo<long, long, long>(Math.Max),
        // Static void methods
        GetMethodInfo(Console.Clear),
        GetMethodInfo<string[]>(Main),
        // With explicit cast if too many arguments
        GetMethodInfo((Action<string, object, object>)Console.WriteLine),
        // Instance methods
        GetMethodInfo<string, bool>("".StartsWith),
        GetMethodInfo(new List<int>().Clear),
    };
