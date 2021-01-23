    public class MyDataGrid : DataGrid
    {
    ...
      override OnSorting(DataGridSortingEventArgs eventArgs)
      {
        DataGrid::OnSorting(eventArgs);
        // sorting done
      }
    }
