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
            // split anyway, if there's no colon you just get a one-element
            // array containing s, see
            // http://msdn.microsoft.com/en-us/library/b873y76a.aspx
            foreach(string v in s.Split(','))
            {
                yield return v.Trim();
            }
        }
    }
