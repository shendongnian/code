    for (int i = 0; i < currRow.Values.Length; i++)
    {
        var type = obj.GetType();
        var obj = dataSet.Tables[0].ColumnNames[i], currRow.Values[i];
        var value = null;
        switch (type)
        {
            case DateTime:
                value = DateTime.Parse(obj);
                break;
            case double:
                value = Convert.ToDouble(obj);
                break;
            case string:
                value = Convert.ToString(obj);
                break;
        }
        tuple.Put(dataSet.Tables[0].ColumnNames[i], value);
    }
