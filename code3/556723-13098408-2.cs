    var t = new DataTemplate();
    t.VisualTree = new FrameworkElementFactory((typeof(TextBlock));
    t.VisualTree.SetBinding(new Binding(columnName));
   
    var c = new DataGridTemplateColumn();
    c.CellTemplate = t;
    c.Header = columnName;
    dg.Columns.Add( c );
         
