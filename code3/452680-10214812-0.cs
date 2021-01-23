    static List<double> getValues(string str)
    {
        List<double> list = new List<double>();
        foreach (string item in str.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries))
            list.Add(double.Parse(item));
        return list;
    }
