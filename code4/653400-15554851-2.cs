    List<int> values = new List<int>();
    
    // Add items to list
    // i.e. values.Add(-1);
    values.Sort(delegate(int n1, int n2) { return math.Abs(n1).CompareTo(math.Abs(n2)); });
        
    foreach(var num in values)
    {
    // Do work
    }
