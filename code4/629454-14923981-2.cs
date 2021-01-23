    private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        // Since you want a natural sort in the first column
        if (e.Column.Index == 0)
        {
            // Create an instance of your natural sort comparer here
            IComparer<string> comparer = new YourNaturalComparer()
            // Perform the sort
            e.SortResult = comparer.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());
            // Signal that we handled the sorting for this column
            e.Handled = true;
        }
    }
