    //Tested on LINQPad
    void Main()
    {
        var test = GetDictionary<City>();
        Console.WriteLine(test["London"]);
    }
    public static IDictionary<string, int> GetDictionary<T>()
    {
        Type type = typeof(T);
        if (type.IsEnum)
        {
            var values = Enum.GetValues(type);
            var result = new Dictionary<string, int>();
            foreach (var value in values)
            {
                result.Add(value.ToString(), (int)value);
            }
            return result;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
    public enum City
    {
        London = 1,
        Liverpool = 20,
        Leeds = 25
    }
