    public static string ContriesToString(this List<Country> list)
    {
        var result = new StringBuilder();
        for(int i=0; i<list.Count;i++)
           result.Add(string.Format("{0}:{1}", list[i].Code, list[i].Title));
    
        result.ToString();
    }
