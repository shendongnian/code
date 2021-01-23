    public class Row
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    MyDataGrid.Columns.Add(new DataGridTextColumn { Header = "Id", Binding = new Binding("Id"), Width = 100 });
    MyDataGrid.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name"), Width = 100 });
    MyDataGrid.Items.Add(new Row { Id = 1, Name = "Mr. Anderson"});
    MyDataGrid.Items.Add(new Row { Id = 2, Name = "John Smith"});
