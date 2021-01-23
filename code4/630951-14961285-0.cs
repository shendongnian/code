    //In your example you have 5 columns    
    for (int c = 0; c < 5; c++)
    {
      DataGridTemplateColumn column = new DataGridTemplateColumn();
      //Basically i will wrap your DataTemplate in a ContentPresenter
      //The ContentProperty is set to point to the correct element of your list                  
      var factory = new FrameworkElementFactory(typeof(ContentPresenter));
      factory.SetBinding(ContentPresenter.ContentProperty, new Binding(string.Format("[{0}]", c.ToString())));
      factory.SetValue(ContentPresenter.ContentTemplateProperty, this.FindResource("YourTemplateName") as DataTemplate);
      column.SetValue(DataGridTemplateColumn.CellTemplateProperty, new DataTemplate { VisualTree = factory });
      myDataGrid.Columns.Add(column);
    }
