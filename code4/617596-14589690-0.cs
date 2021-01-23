    public static DependencyProperty MyItemProperty = DependencyProperty.Register("MyItem", typeof(object), typeof(MyViewModel), new PropertyMetadata(string.Empty, ItemChanged));
     private static void ItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
            var obj = d as MyViewModel;
            obj.RaisePropChangeEvent("MyItem");
    }
