    private void ListBox1_Tap(object sender, GestureEventArgs e)
    {
        var selectedItem = (ListBoxItem)ListBox1.SelectedItem;
        if (selectedItem != null)
        {
            var y = (string)selectedItem.Content;
            var filteredFactors = (from factor in data.factors
                                   where factor.col1 == y
                                   select factor.Item1);
            //filteredFactors is IEnumerable
            this.DataContext = filteredFactors;
            // if you need the first only or nothing if there is none.
            this.DataContext = filteredFactors.FirstOrDefault();
            // if there can be nothing or only one
            this.DataContext = filteredFactors.SingleOrDefault();
        }
    }
