       private void datagrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            rows2change.Add(e.Row.GetIndex());
        }
        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (rows2change.Count > 0)
            {
                saveMyData(rows2change[0]);
                rows2change.Remove(rows2change[0]);
            }
        }
