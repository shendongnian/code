    <DataGrid Name="dataGrid" AutoGenerateColumns="True" AutoGeneratingColumn="dataGrid_AutoGeneratingColumn" />
     private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
     {
        e.Column = new DataGridTextColumn() { Header = e.PropertyName, Binding = new Binding("[" + e.PropertyName + "]") };
     }
