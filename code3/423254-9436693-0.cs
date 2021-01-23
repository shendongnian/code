    private static Dictionary<string, string> _extractDictionary(string str)
    {
        var query = from name_value in str.Split(';')   // Split by ;
                    let arr = name_value.Split('=')     // ... then by =
                    select new {Name = arr[0], Value = arr[1]};
        return query.ToDictionary(x => x.Name, y => y.Value);
    }
    public static void Main()
    {
        var str = "ImageDimension=655x0;ThumbnailDimension=0x0";
        var dic = _extractDictionary(str);
        foreach (var key_value in dic)
        {
            var key = key_value.Key;
            var value = key_value.Value;
            Console.WriteLine("Value of {0} is {1}.", key, value.Substring(0, value.IndexOf("x")));
        }
    }
