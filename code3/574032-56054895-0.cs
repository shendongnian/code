        public static  void ClearSort(this DataGrid grid)
        {
            var view = CollectionViewSource.GetDefaultView(grid.ItemsSource);
            view?.SortDescriptions.Clear();
            foreach (var column in grid.Columns)
            {
                column.SortDirection = null;
            }
        }
