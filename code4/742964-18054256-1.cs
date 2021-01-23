    public bool Validate(string str)
    {
        var data = str.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
        double n;
        return data.Length == 2 ? Double.TryParse(data[0], out n) && !String.IsNullOrWhiteSpace(data[1]) : false;
    }
    ...
    bool valid = Validate("::234::some's text's::");
