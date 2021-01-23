    if (Application.Current.Dispatcher.CheckAccess())
    {
        UpdateCollectionView(e.CustomersInfo);
    }
    else
    {
        Application.Current.Dispatcher.Invoke(new Action(() => UpdateCollectionView(e.CustomersInfo)));
    }
    private void UpdateCollectionView(IEnumerable<Customer> customers)
    {
        Customers = CollectionViewSource.GetDefaultView(customers);
        Customers.SortDescriptions.Clear();
        Customers.SortDescriptions.Add(new SortDescription("CreationDate", ListSortDirection.Descending));
        Customers.Refresh();
    }
