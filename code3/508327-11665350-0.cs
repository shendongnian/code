    foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Selected = false;
            }
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
