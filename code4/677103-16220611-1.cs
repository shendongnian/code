    public class MyDataGrid : DataGrid
    {
    ...
      override OnSorting(DataGridSortingEventArgs eventArgs)
      {
        // sorting begins
        DataGrid::OnSorting(eventArgs);
        // sorting done
      }
    }
