    var gxDict = new Dictionary<string, List<Tuple<int, int>>>();
    List<Tuple<int, int>> currentGxList = null;
    foreach(string line in File.ReadLines(path))
    {
        if (line.StartsWith("#Pattern"))
        {
            string[] headers = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string patternField = headers.First();
            string patterName = string.Join(" ", patternField.Split().Skip(1).Take(2));
            List<Tuple<int, int>> gxList = null;
            if (gxDict.TryGetValue(patterName, out gxList))
                currentGxList = gxList;
            else
            {
                currentGxList = new List<Tuple<int, int>>();
                gxDict.Add(patterName, currentGxList);
            }
        }
        else
        {
            if (currentGxList != null)
            {
                string[] values = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int gx1;
                int gy1;
                string gx1Str = values.ElementAtOrDefault(3);
                string gy1Str = values.ElementAtOrDefault(4);
                if (int.TryParse(gx1Str, out gx1) && int.TryParse(gx1Str, out gx1))
                {
                    currentGxList.Add(Tuple.Create(gx1, gy1));
                }
            }
        }
