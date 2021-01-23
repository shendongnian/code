    var gxDict = new Dictionary<string, List<Tuple<double, double>>>();
    List<Tuple<double, double>> currentGxList = null;
    foreach (string line in File.ReadLines(filePath))
    {
        if (line.StartsWith("#Pattern"))
        {
            string[] headers = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string patternField = headers.First();
            string patterName = string.Join(" ", patternField.Split().Skip(1).Take(2));
            List<Tuple<double, double>> gxList = null;
            if (gxDict.TryGetValue(patterName, out gxList))
                currentGxList = gxList;
            else
            {
                currentGxList = new List<Tuple<double, double>>();
                gxDict.Add(patterName, currentGxList);
            }
        }
        else
        {
            if (currentGxList != null)
            {
                string[] values = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                double gx1;
                double gy1;
                string gx1Str = values.ElementAtOrDefault(3);
                string gy1Str = values.ElementAtOrDefault(4);
                if (double.TryParse(gx1Str, out gx1) && double.TryParse(gx1Str, out gy1))
                {
                    currentGxList.Add(Tuple.Create(gx1, gy1));
                }
            }
        }
    }
