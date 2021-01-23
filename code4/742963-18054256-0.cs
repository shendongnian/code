    public bool Validate(string str)
    {
        var data = str.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
        double n;
        return Double.TryParse(data[0], out n) && !String.IsNullOrWhiteSpace(data[1]);
    }
    ...
    bool valid = Validate("::234::some's text's::");
