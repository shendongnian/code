    private void lv_answers_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        ListView lv = sender as ListView;
        // the data types of the columns:
        // s=string, d=datetime, n = integer, -=excluded
        string colTypes = "n-sd";  // five columns: numeric, excluded, string, date
        string lvSort = "As0";
        if (lv.Tag != null) lvSort = lv.Tag.ToString();
        if (e.Column < 0 || e.Column > colTypes.Length - 1) return;
        char sortType = colTypes[e.Column];
        if (sortType == '-') return; 
       
        int  sortCol = Convert.ToInt32(lvSort.Substring(2));
        bool asc = lvSort[0] == 'A';
        if (e.Column == sortCol) asc = !asc;
        DateTime dummyD;
        double dummyN;
        double maxDate = DateTime.MaxValue.ToOADate();
        int order = asc ? 1 : -1;
        List<ListViewItem> sorted = null;
        try {
        if (sortType == 'n')   // numbers
            sorted = lv.Items.Cast<ListViewItem>().Select(x => x)
                    .OrderBy(x => order * Convert.ToDouble(
                     double.TryParse(x.SubItems[e.Column].Text, out dummyF)   
                     ? x.SubItems[e.Column].Text : double.MinValue.ToString())).ToList();
        else if (sortType == 'd')   // dates
            sorted = lv.Items.Cast<ListViewItem>().Select(x => x)
                    .OrderBy(x => (Convert.ToDateTime(
                     DateTime.TryParse(x.SubItems[e.Column].Text, out dummyD)
                     ? x.SubItems[e.Column].Text : "1900-01-01").ToOADate()*order)).ToList();
        else  // strings
        {
            if (asc)
                sorted = lv.Items.Cast<ListViewItem>().Select(x => x)
                           .OrderBy(x => (x.SubItems[e.Column].Text)).ToList();
            else sorted = lv.Items.Cast<ListViewItem>().Select(x => x)
                           .OrderByDescending(x => (x.SubItems[e.Column].Text)).ToList();
        }
        } catch (ArgumentOutOfRangeException ex) { return; }
        lv.Items.Clear();
        lv.Items.AddRange(sorted.ToArray());
        lv.Tag = "" + (asc ? "A" : "D") + sortType.ToString() + e.Column;
    }
