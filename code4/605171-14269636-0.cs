    foreach (T key in columns.Keys)
    {
        pair = columns[key];
        d = data[key];
        output.Append(pair.Value);
        output.Append(",");
        output.Append(d.Value);
        output.Append(Environment.NewLine);
    }
