    string pageNos = "1,2,3,4,8,9,10,15";
    // Get list of numbers as ints
    var list = pageNos.Split(',').Select(i => Convert.ToInt32(i)).ToList();
    // Get a list of numbers and ranges of consecutive numbers
    var ranges = new List<Tuple<int, int>>();
    int start = 0;
    for (int i = 0; i < list.Count; i++)
    {
        // First item always starts a new range
        if (i == 0)
        {
            start = list[i];
        }
        // Last item always ends the current range
        if (i == list.Count - 1)
        {
            if (list[i] == list[i - 1] + 1)
            {
                ranges.Add(new Tuple<int, int>(start, list[i] - start));
            }
            else
            {
                ranges.Add(new Tuple<int, int>(start, list[i - 1] - start));
                ranges.Add(new Tuple<int, int>(list[i], 0));
            }
        }
        // End the current range if nonsequential
        if (i > 0 && i < list.Count - 1 && list[i] != list[i - 1] + 1)
        {
            ranges.Add(new Tuple<int, int>(start, list[i - 1] - start));
            start = list[i];
        }
    }
    // Craete the result string
    var result = string.Join(", ", ranges.Select(r => r.Item2 == 0 ? r.Item1.ToString() : string.Format("{0}-{1}", r.Item1, r.Item1 + r.Item2)));
