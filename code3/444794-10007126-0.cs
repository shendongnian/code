    Dictionary<string, int[]> plots = new Dictionary<string, int[]>();
    plots.Add("px1", new int[] { 90, 70, 100, 80, 60, 50, 70, 90, 75, 65 });
    plots.Add("px2", new int[] { 5, 10, 15, 20, 25, 30, 18, 12, 20, 10 });
    plots.Add("px3", new int[] { 15, 20, 15, 8, 3, 12, 28, 32, 12, 20 });
    plots.Add("px4", new int[] { 20, 30, 10, 3, 5, 8, 24, 28, 15, 18 });
    plots.Add("px5", new int[] { 60, 85, 32, 9, 15, 24, 70, 84, 45, 54 });
    plots.Add("px6", new int[] { 10, 15, 18, 44, 12, 16, 25, 22, 16, 25 });
    string test = "px4";
    string winner = string.Empty;
    double smallestAverage = double.MaxValue;
    foreach (string key in plots.Keys)
    {
        if (key == test)
        {
            continue;
        }
        int[] a = plots[test];
        int[] b = plots[key];
        int count = 0;
        for (int point = 0; point <= 9; point++)
        {
            count += Math.Abs(a[point] - b[point]);
        }
        double average = count / 10;
        if (average < smallestAverage)
        {
            smallestAverage = average;
            winner = key;
        }
    }
    Console.WriteLine("Winner: {0}", winner);
