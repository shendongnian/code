    string[] str = { "one", "two", "three", "f", "o", "u", "r" };
    List<string> output = new List<string>();
    StringBuilder builder = null;
    bool merge = false;
    foreach(string item in str)
    {
        if (item.Length == 1)
        {
            if (!merge)
            {
                merge = true;
                builder = new StringBuilder();
            }
            builder.Append(item);
        }
        else
        {
            if (merge)
                output.Add(merge.ToString());
            merge = false;
            output.Add(item);
        }
    }
    if (merge)
        output.Add(builder.ToString());
