        var buttonTemplate = new FrameworkElementFactory(typeof(Button));
        var text = new FrameworkElementFactory(typeof(TextBlock));
        text.SetValue(TextBlock.TextProperty, "Save");
        buttonTemplate.AppendChild(text);
        buttonTemplate.AddHandler(
            System.Windows.Controls.Primitives.ButtonBase.ClickEvent,
            new RoutedEventHandler((o, e) => MessageBox.Show("hi"))
        );
        AccountDatagrid.Columns.Add(new DataGridTemplateColumn()
        {
            Header = "Save",
            CellTemplate = new DataTemplate() { VisualTree = buttonTemplate }
        });
        AccountDatagrid.ItemsSource = AccoutDescCodeTime.GetBaseAccounts();
