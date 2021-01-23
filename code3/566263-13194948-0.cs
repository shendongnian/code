    List<List<double>> result = new List<List<double>>();
    List<double> current = new List<double>();
    foreach (double d in values)
    {
        if (d == double.NaN)
        {
            result.Add(current);
            current = new List<double>();
        }
        else
        {
            current.Add(d);
        }
    }
    result.Add(current);
