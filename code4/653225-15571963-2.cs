    public MainViewModel()
            {
    Datatable.Columns.Add("Name",typeof(string));
                Datatable.Columns.Add("Color", typeof(string));
                Datatable.Columns.Add("Phone", typeof(string));
                Datatable.Rows.Add("Vinoth", "#00FF00", "456345654");
                Datatable.Rows.Add("lkjasdgl", "Blue", "45654");
                Datatable.Rows.Add("Vinoth", "#FF0000", "456456");
    System.Windows.Data.Binding bindings = new System.Windows.Data.Binding("Name");
                System.Windows.Data.Binding bindings1 = new System.Windows.Data.Binding("Phone");
                System.Windows.Data.Binding bindings2 = new System.Windows.Data.Binding("Color");
                DataGridTextColumn s = new DataGridTextColumn();
                s.Header = "Name";
                s.Binding = bindings;
                DataGridTextColumn s1 = new DataGridTextColumn();
                s1.Header = "Phone";
                s1.Binding = bindings1;
                DataGridTextColumn s2 = new DataGridTextColumn();
                s2.Header = "Color";
                s2.Binding = bindings2;
    
                FrameworkElementFactory textblock = new FrameworkElementFactory(typeof(TextBlock));
                textblock.Name = "text";
                System.Windows.Data.Binding prodID = new System.Windows.Data.Binding("Name");
                System.Windows.Data.Binding color = new System.Windows.Data.Binding("Color");
                textblock.SetBinding(TextBlock.TextProperty, prodID);
                textblock.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
                //textblock.SetValue(TextBlock.BackgroundProperty, color);
                textblock.SetValue(TextBlock.NameProperty, "textblock");
                //FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
                //border.SetValue(Border.NameProperty, "border");
                //border.AppendChild(textblock);
                DataTrigger t = new DataTrigger();
                t.Binding = new System.Windows.Data.Binding { Path = new PropertyPath("Name"), Converter = new EnableConverter(), ConverterParameter ="Phone" };
                t.Value = 1;
                t.Setters.Add(new Setter(TextBlock.BackgroundProperty, Brushes.LightGreen, textblock.Name));
                t.Setters.Add(new Setter(TextBlock.ToolTipProperty, bindings, textblock.Name));
                DataTrigger t1 = new DataTrigger();
                t1.Binding = new System.Windows.Data.Binding { Path = new PropertyPath("Name"), Converter = new EnableConverter(), ConverterParameter = "Phone" };
                t1.Value = 2;
                t1.Setters.Add(new Setter(TextBlock.BackgroundProperty, Brushes.LightYellow, textblock.Name));
                t1.Setters.Add(new Setter(TextBlock.ToolTipProperty, bindings, textblock.Name));
    
                DataTemplate d = new DataTemplate();
                d.VisualTree = textblock;
                d.Triggers.Add(t);
                d.Triggers.Add(t1);
                
                DataGridTemplateColumn s3 = new DataGridTemplateColumn();
                s3.Header = "Name 1";
                s3.CellTemplate = d;
                s3.Width = 140;
    
                ColumnCollection.Add(s); 
                ColumnCollection.Add(s1);
                ColumnCollection.Add(s2);
                ColumnCollection.Add(s3);
        }
