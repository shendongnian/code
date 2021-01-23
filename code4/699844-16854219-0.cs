	public void MySort(DataGridSortingEventArgs args)
		{
			//create a collection view for the datasource binded with grid
			ICollectionView dataView = CollectionViewSource.GetDefaultView(this.ItemsSource);
			//clear the existing sort order
			dataView.SortDescriptions.Clear();
			ListSortDirection sortDirection = args.Column.SortDirection ?? ListSortDirection.Ascending;
			//create a new sort order for the sorting that is done lastly
			dataView.SortDescriptions.Add(new SortDescription(args.Column.SortMemberPath, sortDirection));
			//refresh the view which in turn refresh the grid
			dataView.Refresh();
		}
