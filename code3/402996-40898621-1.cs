    private void dgvAllMyEmployees_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        DataGridViewColumn dgvcClicked = dgvAllEmployees.Columns[e.ColumnIndex];
        if (dgvcClicked.SortMode == DataGridViewColumnSortMode.Programmatic)
        {
            _SortOrder = (_SortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            MyTwoColumnComparer Sort2C = new MyTwoColumnComparer(dgvcClicked.Name, _SortOrder, "LastName", SortOrder.Ascending);
            dgvAllEmployees.Sort(Sort2C);
        }
    }
