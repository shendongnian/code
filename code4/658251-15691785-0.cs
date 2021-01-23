    // reproduce data
    List<double[]> DataList = new List<double[]>();
    DataList.Add(new double[] { 2, 3, 5, 6, 8 });
    DataList.Add(new double[] { 2, 3, 5, 6, 9 });
    DataList.Add(new double[] { 2, 3, 5, 6, 5 });
    DataList.Add(new double[] { 2, 3, 5, 6, 12 });
    var ordered = DataList.OrderByDescending(l => l.Last());
