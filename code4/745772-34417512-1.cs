    public class CustomSortBehaviour
    {
    	#region Fields and Constants
    
    	public static readonly DependencyProperty CustomSorterProperty =
    		DependencyProperty.RegisterAttached("CustomSorter", typeof (ICustomSorter), typeof (CustomSortBehaviour));
    
    	public static readonly DependencyProperty AllowCustomSortProperty =
    		DependencyProperty.RegisterAttached("AllowCustomSort",
    			typeof (bool),
    			typeof (CustomSortBehaviour),
    			new UIPropertyMetadata(false, OnAllowCustomSortChanged));
    
    
    
    	#endregion
    
    	#region public Methods
    
    	public static bool GetAllowCustomSort(DataGrid grid)
    	{
    		return (bool) grid.GetValue(AllowCustomSortProperty);
    	}
    
    
    	public static ICustomSorter GetCustomSorter(DataGrid grid)
    	{
    		return (ICustomSorter)grid.GetValue(CustomSorterProperty);
    	}
    
    	public static void SetAllowCustomSort(DataGrid grid, bool value)
    	{
    		grid.SetValue(AllowCustomSortProperty, value);
    	}
    
    
    	public static void SetCustomSorter(DataGrid grid, ICustomSorter value)
    	{
    		grid.SetValue(CustomSorterProperty, value);
    	}
    
    	#endregion
    
    	#region nonpublic Methods
    
    	private static void HandleCustomSorting(object sender, DataGridSortingEventArgs e)
    	{
    		var dataGrid = sender as DataGrid;
    		if (dataGrid == null || !GetAllowCustomSort(dataGrid))
    		{
    			return;
    		}
    
    		var listColView = dataGrid.ItemsSource as ListCollectionView;
    		if (listColView == null)
    		{
    			throw new Exception("The DataGrid's ItemsSource property must be of type, ListCollectionView");
    		}
    
    		// Sanity check
    		var sorter = GetCustomSorter(dataGrid);
    		if (sorter == null)
    		{
    			return;
    		}
    
    		// The guts.
    		e.Handled = true;
    
    		var direction = (e.Column.SortDirection != ListSortDirection.Ascending)
    			? ListSortDirection.Ascending
    			: ListSortDirection.Descending;
    
    		e.Column.SortDirection = sorter.SortDirection = direction;
    		sorter.SortMemberPath = e.Column.SortMemberPath;
    
    		listColView.CustomSort = sorter;
    	}
    
    	private static void OnAllowCustomSortChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		var existing = d as DataGrid;
    		if (existing == null)
    		{
    			return;
    		}
    
    		var oldAllow = (bool) e.OldValue;
    		var newAllow = (bool) e.NewValue;
    
    		if (!oldAllow && newAllow)
    		{
    			existing.Sorting += HandleCustomSorting;
    		}
    		else
    		{
    			existing.Sorting -= HandleCustomSorting;
    		}
    	}
    
    	#endregion
    }
