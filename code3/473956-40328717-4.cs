    static class LvHelper
    {
        public static void SortByColumn(this ListView lv, string colTypes, 
                                        ColumnClickEventArgs e)
        {
            string lvSort = "As0";
            if (lv.Tag != null) lvSort = lv.Tag.ToString();
            if (e.Column < 0 || e.Column > colTypes.Length - 1) return;
            char sortType = colTypes[e.Column];
            if (sortType == '-') return;
            int mini = lv.Items.Cast<ListViewItem>().Select(x => x.SubItems.Count).Min();
            if (sortType != 's'  && lv.Items.Cast<ListViewItem>()
                                .Select(x => x.SubItems.Count - 1).Min() < e.Column) return;
            int  sortCol = Convert.ToInt32(lvSort.Substring(2));
            bool asc = lvSort[0] == 'A';
            if (e.Column == sortCol) asc = !asc;
            DateTime dummyD;
            double dummyN;
            double maxDate = DateTime.MaxValue.ToOADate();
            int order = asc ? 1 : -1;
            List<ListViewItem> sorted = null;
            try
            {
                if (sortType == 'n')   // numbers
                    sorted = lv.Items.Cast<ListViewItem>().Select(x => x)
                             .OrderBy(x => order * Convert.ToDouble(
                              double.TryParse(x.SubItems[e.Column].Text, out dummyN)
                                    ? x.SubItems[e.Column].Text 
                                    : (double.MinValue / 2).ToString())).ToList();
                else if (sortType == 'd')   // dates
                    sorted = lv.Items.Cast<ListViewItem>().Select(x => x)
                             .OrderBy(x => (Convert.ToDateTime(
                              DateTime.TryParse(x.SubItems[e.Column].Text, out dummyD)
                                      ? x.SubItems[e.Column].Text 
                                      : "1900-01-01").ToOADate() * order)).ToList();
                else  // strings
                {
                    if (asc)
                        sorted = lv.Items.Cast<ListViewItem>().Select(x => x)
                                   .OrderBy(x => x.SubItems.Count -1 < e.Column 
                                   ? "" : (x.SubItems[e.Column].Text)).ToList();
                    else sorted = lv.Items.Cast<ListViewItem>().Select(x => x)
                                   .OrderByDescending(x => x.SubItems.Count -1 < e.Column 
                                   ? "" : (x.SubItems[e.Column].Text)).ToList();
                }
            }
            catch (ArgumentOutOfRangeException ex) { return; }
            lv.Items.Clear();
            lv.Items.AddRange(sorted.ToArray());
            lv.Tag = "" + (asc ? "A" : "D") + sortType.ToString() + e.Column;
        }
    }
