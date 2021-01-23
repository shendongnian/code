    static void Main()
    {
        Dictionary<ICD_Map2, string> maps = new Dictionary<ICD_Map2, string> {
            {new ICD_Map2 ("Mobile SMS", "Australia"),"Local Text"},
            {new ICD_Map2 ("Mobile SMS", "International"),"International Text"}
        };
        // try forwards lookup
        var key = new ICD_Map2("Mobile SMS", "Australia");
        string result;
        if (maps.TryGetValue(key, out result))
        {
            Console.WriteLine("found: " + result);
        }
        // try reverse lookup (less efficient)
        result = "International Text";
        key = (from pair in maps
                   where pair.Value == result
                   select pair.Key).FirstOrDefault();
        if (key != null)
        {
            Console.WriteLine("found: " + key);
        }
    }
