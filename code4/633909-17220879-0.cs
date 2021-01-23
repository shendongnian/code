    public static class Extensions
    {
        public static void ClearColumn(this DataGridView dgv, int columnIndex)
        {
            if (dgv.Columns != null && dgv.Columns.Count - 1 >= columnIndex)
            {
                var tmpCol = dgv.Columns[columnIndex];
                dgv.Columns.Remove(dgv.Columns[columnIndex]);
                dgv.Columns.Insert(columnIndex, tmpCol);
            }
        }
    }  
