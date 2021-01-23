    var take = 3;
    var skip = 2;
    StringBuilder source = new StringBuilder("ABCDEFGHIJKL");            
    StringBuilder result = new StringBuilder();
    while (source.Length > 0)
    {
        if (source.Length >= take)
        {
            result.Append(source.ToString().Substring(0, take));
        }
        else
        {
            result.Append(source.ToString());
        }
        if (source.Length > skip + take)
        {
            source.Remove(0, skip + take);
        }
        else
            source.Clear();
    }
