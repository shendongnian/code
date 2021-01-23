    using System.Windows.Data;
    using System.ComponentModel;
			ICollectionView view = CollectionViewSource.GetDefaultView(grid.ItemsSource);
			if (view != null && view.SortDescriptions != null)
			{
				view.SortDescriptions.Clear();
				foreach (var column in grid.Columns)
				{
					column.SortDirection = null;
				}
			}
