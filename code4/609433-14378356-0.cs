    DataTable dtab = new DataTable();
    dtab.Columns.Add("imageColumn", typeof(BitmapImage)); 
    //Uploading dtab with Images from DataBase
 
    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(Image));
    Binding bind = new System.Windows.Data.Binding("imageColumn");
    factory.SetValue(Image.SourceProperty, bind);
    DataTemplate cellTemplate = new DataTemplate() { VisualTree = factory };
    DataGridTemplateColumn imgCol = new DataGridTemplateColumn() 
    {
      Header="image",
      CellTemplate = cellTemplate
    };
    DataGrid dg = new DataGrid();
    dg.Columns.Add(imgCol);
    dg.ItemsSource = dtab.DefaultView;
