    List<double> doubleList = new List<double>();
    for (int t = 2; t < test.Length; t++)
    {
        doubleList.Add(double.Parse(test[t].Substring(6, 4)));    
    }
