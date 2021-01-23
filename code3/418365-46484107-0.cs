    List<int> TagIds = new List<int>();
    string[] split = tags.Split(',');
    foreach (string item in split)
    {
        int val = 0;
        if (int.TryParse(item, out val) == true)
        {
            TagIds.Add(val);
        }
    }
