        DataTable dt1 = new DataTable();
        dt1.Columns.Add("col1", typeof(String));
        dt1.Columns.Add("col2", typeof(String));
        dt1.Columns.Add("col3", typeof(String));
        dt1.Columns.Add("col4", typeof(String));
        DataTable dt2 = new DataTable();
        dt2.Columns.Add("col5", typeof(String));
        dt2.Columns.Add("col6", typeof(String));
        dt1.Merge(dt2);
