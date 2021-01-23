    public double[] Resources
    {
        get
        {
            var result = from r in ResourceString.Split(';')
                         select double.Parse(r);
    
            return result.ToArray();
        }
        set
        {
            ResourceString = string.Empty;
            foreach (var d in value)
            {
                ResourceString += d + ";";
            }
        }
    }
    
    private string ResourceString
    {
        get;
        set;
    }
