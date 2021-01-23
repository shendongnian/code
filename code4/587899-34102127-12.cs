    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
       e.Column = new DataGridTextColumn() { 
           Header = e.PropertyName, 
           SortMemberPath = e.PropertyName, //To allow for sorting on a column 
           Binding = new Binding("[" + e.PropertyName + "]") 
       };
    }
