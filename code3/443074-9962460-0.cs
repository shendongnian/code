    public bool IsInt(this string inputData)
    {
        Regex isNumber = new Regex(@"^\d+$");
        Match m = isNumber.Match(inputData);
    
        return m.Success;
    }
