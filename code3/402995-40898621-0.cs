    public class MyTwoColumnComparer : System.Collections.IComparer
    {
        private string _SortColumnName1;
        private int _SortOrderMultiplier1;
        private string _SortColumnName2;
        private int _SortOrderMultiplier2;
        public MyTwoColumnComparer(string pSortColumnName1, SortOrder pSortOrder1, string pSortColumnName2, SortOrder pSortOrder2)
        {
            _SortColumnName1 = pSortColumnName1;
            _SortOrderMultiplier1 = (pSortOrder1 == SortOrder.Ascending) ? 1 : -1;
            _SortColumnName2 = pSortColumnName2;
            _SortOrderMultiplier2 = (pSortOrder2 == SortOrder.Ascending) ? 1 : -1;
        }
        public int Compare(object x, object y)
        {
            DataGridViewRow r1 = (DataGridViewRow)x;
            DataGridViewRow r2 = (DataGridViewRow)y;
            int iCompareResult = _SortOrderMultiplier1 * String.Compare(r1.Cells[_SortColumnName1].Value.ToString(), r2.Cells[_SortColumnName1].Value.ToString());
            if (iCompareResult == 0) iCompareResult = _SortOrderMultiplier2 * String.Compare(r1.Cells[_SortColumnName2].Value.ToString(), r2.Cells[_SortColumnName2].Value.ToString());
            return iCompareResult;
        }
    }
