    private static void AllItemsChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        Foobar control = sender as Foobar;
        if (control != null)
        {
            var newEnumerable = (IEnumerable<string>)e.NewValue;
            var sorted = newEnumerable.OrderBy(s => s, new CustomSort());
            var source = new List<string>(sorted);
            
            var view = (ListCollectionView)CollectionViewSource.GetDefaultView(source);
            control.listbox.ItemsSource = view;
            control.ApplyFilter();
        }
    }
    private class CustomSort : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return String.Compare(x, y, CultureInfo.CurrentUICulture, CompareOptions.IgnoreCase);
        }
    }
