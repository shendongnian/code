    foreach (var column in myTable.Columns.OfType<DataColumn>())
    {
        string name = column.ColumnName;
    
        char[] chars = s.ToCharArray();
        chars[0] = char.ToUpper(chars[0]);
        column.ColumnName = new string(chars);
    }
