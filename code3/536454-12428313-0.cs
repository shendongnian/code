    private void PerformCustomSort(DataGridColumn column) {
            ListSortDirection direction = (column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            column.SortDirection = direction;
            List<DataGridRow> dgRows = new List<DataGridRow>();
            var itemsSource = dataGrid1.ItemsSource as IEnumerable;
            if (null != itemsSource)
            foreach (var item in itemsSource) {
                DataGridRow row = dataGrid1.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) {
                    dgRows.Add(row);
                }
            }
            ListCollectionView lcv = new ListCollectionView(dgRows);
            SortOrders mySort = new SortOrders(direction, column);
            lcv.CustomSort = mySort;
            dataGrid1.ItemsSource = lcv;
        }
