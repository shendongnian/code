    if (String.IsNullOrWhiteSpace(line))
     continue;
    
    string[] columns = line.TrimLeft().Split(new char[] { ' ' }, 2);
    if (columns.Length > 1)
     list.Add(columns[0]);
