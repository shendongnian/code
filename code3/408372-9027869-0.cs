    public List<Options> ParseOptions(Options options)      
    {
        Array values = Enum.GetValues(typeof(myEnum));
        var list = new List<Options>(); 
        foreach(MyEnum val in values)
        {
            if ((val & options) == val)
                List.Add(val);
        }
        return list;
    }
