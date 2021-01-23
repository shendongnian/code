        private void tb_filter_textChanged(object sender, TextChangedEventArgs e)
        {
            Dictionary<string, string> dictObject = new Dictionary<string, string>();
            ICollectionView view = CollectionViewSource.GetDefaultView(dictObject);
            view.Filter = CustomerFilter;
            listboxname.ItemsSource = view;
        }
        private bool CustomerFilter(object item)
        {
            KeyValuePair<string, string> Items = (KeyValuePair<string,string>) item;
            return Items.Value.ToString().Contains("a");
        }
