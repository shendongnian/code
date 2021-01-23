        private void SetSortColumn(int indexOfColumn)
        {
            if (indexOfColumn != null && indexOfColumn != -1)
            {
                ListSortDirection listSort;
                switch (Properties.Settings.Default.sortingColumnSortMode)
                {
                    case SortOrder.Ascending:
                        listSort = ListSortDirection.Ascending;
                        break;
                    case SortOrder.Descending:
                        listSort = ListSortDirection.Descending;
                        break;
                    default:
                        listSort = ListSortDirection.Descending;
                        break;
                }
                this.dataGridView.Sort(this.dataGridView.Columns[indexOfColumn], listSort);
            }
        }
