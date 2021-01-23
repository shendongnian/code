    class SubtractConverter : IValueConverter
    {
        public double Amount { get; set; }
        public object Convert(object v, Type t, object p, string l)
        { return System.Convert.ToDouble(v) - Amount; }
        public object ConvertBack(object v, Type t, object p, string l)
        { throw new NotImplementedException(); }
    }
        
    private void GridView_OnLayoutUpdated(object sender, RoutedEventArgs e)
    {
        var grid = sender as GridView;
        var converter = new SubtractConverter { Amount = 5 * 2 /* padding x2 */ };
        foreach (GroupItem group in (grid.ItemsPanelRoot as Panel).Children)
        {
            var result = VisualTreeHelper.GetChild(group, 0);
            while (!(result is Grid))
                result = VisualTreeHelper.GetChild(result, 0);
            var items = (result as Panel).Children.OfType<ItemsControl>()
                .First().ItemsPanelRoot;
            var binding = new Binding
            {
                Path = new PropertyPath("ActualWidth"),
                Mode = BindingMode.OneWay,
                Converter = converter,
                Source = items,
            };
            var header = (result as Panel).Children.OfType<ContentControl>()
                .First().ContentTemplateRoot as FrameworkElement;
            header.SetBinding(FrameworkElement.WidthProperty, binding);
        }
    }
