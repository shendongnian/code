    public static void Main()
    {
        List<string> orig = new List<string>()
        {
            "value a",
            "value b",
            "value c",
            "value 1, value 2, value 3",
            "value d"
        };
    
        var result = Flatten(orig).ToList();
    
        foreach(string s in result)
        {
            Console.WriteLine(s);
        }
    }
    
    private static IEnumerable<string> Flatten(IList<string> orig)
    {
        foreach(string s in orig)
        {
            // split anyway, if there's no colon you just get one
            // result which is equal to the original s
            foreach(string v in s.Split(','))
            {
                yield return v.Trim();
            }
        }
    }
