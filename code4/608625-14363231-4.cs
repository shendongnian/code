    DataGridTextColumn column = new DataGridTextColumn();
    column.Header = "Name";
    column.Binding = new Binding("Name")
    {
          Mode = BindingMode.TwoWay,
          UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged                
    };
    column.ElementStyle = this.FindResource("MyStyle") as Style;
    grid.Columns.Add(column);
    
    List<Foo> _source = new List<Foo> 
    {
            new Foo{ Name ="test1"},
            new Foo{ Name ="test2"},
            new Foo{ Name ="test3"}
    };
    
    grid.ItemsSource = _source;
