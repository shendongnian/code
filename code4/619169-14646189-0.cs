    var dg = new DataGrid();
	
    var dataTemplate = new DataTemplate();
			
    var gridFactory = new FrameworkElementFactory(typeof(Grid));
    var checkboxFactory = new FrameworkElementFactory(typeof(CheckBox));
    checkboxFactory.SetBinding(CheckBox.IsCheckedProperty, new Binding("IsSelected") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor,typeof(DataGridRow),1)});
    gridFactory.AppendChild(checkboxFactory);
		
    dataTemplate.VisualTree = gridFactory;
    dg.RowHeaderTemplate = dataTemplate;
