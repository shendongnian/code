    public static class Global
    {
        public static ObservableCollection<Dictionary<string, Dictionary<string, object>>> operations = new ObservableCollection<Dictionary<string, Dictionary<string, object>>>();
        static ObservableCollection<String> names = new ObservableCollection<string>();
        public static ObservableCollection<String> _Operations
        {
            get
            {               
                return names;
            }
        }
        static Global()
        {
            operations.CollectionChanged += operations_CollectionChanged;
        }
        static void operations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Dictionary<string, Dictionary<string, object>> value in e.OldItems)
                {
                    _Operations.Remove(value.Keys.First().ToString( ));
                }
            }
            if (e.NewItems != null)
            {
                foreach (Dictionary<string, Dictionary<string, object>> value in e.NewItems)
                {
                    _Operations.Add(value.Keys.First().ToString());
                }
            }
        }
    }
