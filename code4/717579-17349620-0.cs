    List<string> vals = new List<string>();
    int[] data = new int[] { 1, 2, 3, 4 };
    
    for (int i = 0; i < data.Length; i++)
    {
    	vals.Add(string.Format("val{0} = {1}", i + 1, data[i]));
    }
    
    string auxstring = string.Join(",", vals.ToArray());
