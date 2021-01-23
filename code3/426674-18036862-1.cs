    private void DataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        if (e.Column.Name == "YourColumnName") //<== this must be your date column name
        {
            DateTime dt1 = Convert.ToDateTime(e.CellValue1);
            DateTime dt2 = Convert.ToDateTime(e.CellValue2);
            e.SortResult = System.DateTime.Compare(dt1, dt2);
            e.Handled = true;
        }
    }
