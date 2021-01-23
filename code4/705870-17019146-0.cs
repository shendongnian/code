    static List<string> generate(int count)
    {
        List<string> strings = new List<string>();
        while (strings.Count < count)
        {
            Guid g = Guid.NewGuid();                
            string GuidString = g.ToString();
            GuidString = GuidString.Replace("-", "");
            GuidString = GuidString.Remove(16);
            if (!strings.Contains(GuidString))
                strings.Add(GuidString);
        }
        return strings;
    }
          
