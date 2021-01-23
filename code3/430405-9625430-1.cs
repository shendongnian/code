    if (String.IsNullOrWhiteSpace(line))
     continue;
    
    string[] columns = line.TrimLeft().Split(new char[] { ' ' }, 2);
    list.Add(columns[0]);
