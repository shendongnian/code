    private void OnSorting_(object sender, DataGridSortingEventArgs e)
	{
		var viewModel = DataContext as ViewModel;
		e.Handled = true;                                 // prevent DataGrid from sorting
		viewModel.SortItemSource(e.Column);               // perform sorting
		e.Column.SortDirection = viewModel.SortDirection; // set sort direction icon on column header
	}
