    Dictionary<string, int> temp = new Dictionary<string, int>();
    foreach (KeyValuePair<string, int> item in mylist)
    {
        if (temp.ContainsKey(item.Key))
        {
            temp[item.Key] = temp[item.Key] + item.Value;
        }
        else
        {
            temp.Add(item.Key, item.Value);
        }
    }
    List<KeyValuePair<string, int>> result = temp.ToList();
