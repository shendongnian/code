    List<double?> list1 = new List<double?>();
    List<double?> list2 = new List<double?>();
    int recordCount = list1.Count > list2.Count ? list2.Count : list1.Count;
    var results = new double?[recordCount]; // Use an array here
    Parallel.For(0, recordCount, index => 
        {
            double? result = list1[index] + list2[index];
            results[index] = result;
        });
