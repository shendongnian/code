    public static void SortColumn(DataGrid dataGrid, int columnIndex)
    {
        var performSortMethod = typeof(DataGrid)
                                .GetMethod("PerformSort",
                                           BindingFlags.Instance | BindingFlags.NonPublic);
    
        performSortMethod?.Invoke(dataGrid, new[] { dataGrid.Columns[columnIndex] });
    }
