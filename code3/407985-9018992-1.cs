    // this should be renamed in something like columns or fieldCount...
    int row_count = reader.FieldCount;  
    for (int i = 0; i < row_count; i++)
    {
        tabView.Columns.Add(new DataGridTextColumn 
            { 
                Header = reader.GetName(i), 
                Binding = new Binding("Items[i]") 
            });
    }
