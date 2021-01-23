    public List<Options> ParseOptions(Options options)      
    {
        var list = new List<Options>(); 
        foreach(MyEnum val in Enum.GetValues(typeof(myEnum)))
        {
            if ((val & options) == val)
                List.Add(val);
        }
        return list;
    }
