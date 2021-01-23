    protected void grid_CustomColumnSort
    (object sender, DevExpress.Web.ASPxGridView.CustomColumnSortEventArgs e) {
        if (e.Column.FieldName == "Country") {
            e.Handled = true;
            string s1 = e.Value1.ToString(), s2 = e.Value2.ToString();
            if (s1.Length > s2.Length)
                e.Result = 1;
            else
                if (s1.Length == s2.Length)
                    e.Result = Comparer.Default.Compare(s1, s2);
                else
                    e.Result = -1;
        }
    }
