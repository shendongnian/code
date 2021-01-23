    Dictionary<string, int> data=new Dictionary<string, int>();
    foreach(string item in YourInputs)
    {
        if(data.ContainsKey(item)
             data[item]++;
        else
             data.Add(item, 1);
    }
