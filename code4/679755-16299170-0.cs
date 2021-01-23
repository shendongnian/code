    List<List<double>> result = new List<List<double>>();
    foreach (var row in fileContent.Split(new char[] { '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
    {
        List<double> list = new List<double>()
        foreach (var col in row.Trim().Split(' '))
        {
            list.Add(double.Parse(col.Trim(), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo));
        }
        result.Add(list);
    }
