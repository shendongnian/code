    public void MyMethod(IEnumerable<int> arr)
    {
        MyMethod(arr.Select(x => (double)x));  // Call MyMethod(IEnumerable<double>)
    }
    public void MyMethod(IEnumerable<double> arr)
    {
        foreach(double d in arr)               // This code can be used for both.
            Console.WriteLine(d);
    }
    
