    MyViewModel data = GetData();
    int columnIndex = 0; 
     
    foreach (var name in data.ColumnNames) 
    { 
        ValuesDataGrid.Columns.Add( 
            new DataGridTextColumn 
                { 
                    Header = name, 
                    Binding = new Binding(string.Format("Values[{0}]", columnIndex++)) 
                }); 
    } 
    DataContext = data;
