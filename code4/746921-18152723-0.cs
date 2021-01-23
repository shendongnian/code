    private void DataGrid_Loaded_1(object sender, RoutedEventArgs e)
        {
            dataGrid.Columns.Add((DataGridTextColumn)this.Resources["DiscountColumn"]);
            dataGrid.Columns.Add((DataGridTextColumn)this.Resources["NetAmountColumn"]);
            
            //Alternatively you can create columns in .cs like
            dataGrid.Columns.Add(new DataGridTextColumn() { Header = "Dicount", Binding = new Binding("Discount") });
            dataGrid.Columns.Add(new DataGridTextColumn() { Header = "Net Amount", Binding = new Binding("NetAmount") });
        }
    <Window.Resources>
        <DataGridTextColumn x:Key="DiscountColumn" Header="Discount" IsReadOnly="True" Width="*" Binding="{Binding Discount}"/>
        <DataGridTextColumn x:Key="NetAmountColumn" Header="Net Amount" IsReadOnly="True" Width="*" Binding="{Binding NetAmount}"/>
    </Window.Resources>
    <DataGrid RowHeaderWidth="0" x:Name="dataGrid" Loaded="DataGrid_Loaded_1"
