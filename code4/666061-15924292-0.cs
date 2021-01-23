    private void OnWindowLoad(object sender, RoutedEventArgs e)
    {
      var collection = new ObservableCollection<string>();
      ItemListView.ItemsSource = collection;
      var progress = new Progress<string>();
      progress.ProgressChanged += ( s, item ) =>
        {
          collection.Add( item ); // will be raised on the UI thread
        }
      ;
      Task.Run( () => GetItemsAndReport( progress ) );
    }
	void GetItemsAndReport( IProgress<string> progress )
	{
		foreach ( var item in GetItems() ) progress.Report( item );
	}
    private IEnumerable<string> GetItems()
    {
        for (int i = 0; i < 10; i++)
        {
            string item = string.Format("Current string from {0}.", i);
            Thread.Sleep(500);
            yield return item;
        }
    }
