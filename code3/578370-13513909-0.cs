    public IList<string> method()
    {
        var result = new List<string>();
        for (int i = 0; i < 1000; i++)
        {
            result.Add(i.ToString());
        }
        return result;
    }
