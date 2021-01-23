    public class ViewModel 
	{
		public ListCollectionView StatusItemsGrouped { get; set; }
		public ListSortDirection SortDirection { get; set; }
		public string SortColumn { get; set; }
		public void SortItemSource(string columnName)
		{
			if (String.Compare(SortColumn, columnName, true) == 0)
				SortDirection = ListSortDirection.Ascending;
			else
				SortDirection = ListSortDirection.Descending;
			SortColumn = columnName;
			using(StatusItemsGrouped.DeferRefresh()) {
				StatusItemsGrouped.GroupDescriptions.Clear();
				StatusItemsGrouped.SortDescriptions.Clear();
				StatusItemsGrouped.SortDescriptions.Add(new SortDescription(SortColumn, SortDirection));
				StatusItemsGrouped.GroupDescriptions.Add(new PropertyGroupDescription("GenericStatus"));
			}
			StatusItemsGrouped.Refresh();
		}
	}
    
