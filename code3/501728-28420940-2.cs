    public class DataGridSortDescriptionsSyncBehavior : Behavior<DataGrid>
	{
		protected override void OnAttached()
		{
			base.OnAttached();
			
			var view = CollectionViewSource.GetDefaultView(AssociatedObject.ItemsSource);
			var notifyCollection = view.SortDescriptions as INotifyCollectionChanged;
			if (notifyCollection != null)
				notifyCollection.CollectionChanged += SortDescriptions_CollectionChanged;
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			var view = CollectionViewSource.GetDefaultView(AssociatedObject.ItemsSource);
			var notifyCollection = view.SortDescriptions as INotifyCollectionChanged;
			if (notifyCollection != null)
				notifyCollection.CollectionChanged -= SortDescriptions_CollectionChanged;
		}
		private void SortDescriptions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				// clear all columns sort directions
				foreach (var column in AssociatedObject.Columns)
					column.SortDirection = null;
			}
			if (e.NewItems != null)
			{
				// set columns sort directions
				foreach (SortDescription descr in e.NewItems)
					SetSortDirection(descr.PropertyName, descr.Direction);
			}
			if (e.OldItems != null)
			{
				// reset columns sort directions
				foreach (SortDescription descr in e.OldItems)
					SetSortDirection(descr.PropertyName, null);
			}
		}
		private void SetSortDirection(string sortMemberPath, ListSortDirection? direction)
		{
			var column = AssociatedObject.Columns.FirstOrDefault(c => c.SortMemberPath == sortMemberPath);
			if (column != null)
			{
				column.SortDirection = direction;
			}
		}
	}
