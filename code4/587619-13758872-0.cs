    List<int> arr = new List<int>();        
    Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();        
    public override int function(int length, out List<int> cuts)
    {
        cuts = new List<int>();
        if (length < 0)
            return 0;
        if (arr.Count <= length)
        {
            arr.AddRange(new int[(length + 1) - arr.Count])
        }
        if (arr[length] == 0 )
        {
            arr.Insert(length,base.Function(length, out cuts));
            dict.Add(arr[length], cuts);                                
        }
        cuts = dict[arr[length]];
        return arr[length];
    }
