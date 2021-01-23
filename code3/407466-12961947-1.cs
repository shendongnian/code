    ComboBox cb = new ComboBox();
    cb.Width = 100;
    cb.Height = 20;
    Binding b = new Binding("Model.Activity");
    b.Source = this.DataContext;
    cb.SetBinding(ComboBox.ItemsSourceProperty, b);
    string xaml = _Serializer.SerializeControlToXaml(cb);
