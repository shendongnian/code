    var builder = new StringBuilder();
    int count = items.Count();
    int pos = 0;
    foreach (var item in items)
    {
        pos++;
        bool isLast = pos == count;
        bool nextIsLast = pos == count -1;
        if (isLast)
            builder.Append(item);
        else if(nextIsLast)
            builder.Append(item).Append(" and ");
        else
            builder.Append(item).Append(", ");
    }
    string result = builder.ToString();
