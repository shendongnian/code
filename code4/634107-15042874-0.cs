    List<string[]> data;
    data = LoadData();
    var results = new List<object>();
    string[] headerRow;
    var en = data.GetEnumerator();
    while(en.MoveNext())
    {
        var row = en.Current;
        if(string.IsNullOrEmpty(row[0]))
        {
            headerRow = row.Skip(1).ToArray();
        }
        else
        {
            Type objType = Type.GetType(row[0]);
            object newItem = Activator.CreateInstance(objType);
    
            for(int i = 0; i < headerRow.Length; i++)
            {
                objType.GetProperty(headerRow[i]).SetValue(newItem, row[i+1]);
            }
            results.Add(newItem);
        }
    }
