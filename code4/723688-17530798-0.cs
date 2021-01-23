    public int[] GetKeys(string value)
    {
    List<int> list = new List<int>();
    for(int i = 0;i<dict.Values.Count;i++)
    {
    if(dict.Values[i] == value){list.Add(dict.Keys[i]);}
    }
    return list.ToArray();
    }
