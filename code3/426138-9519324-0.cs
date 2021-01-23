    DataTable dt = new DataTable();
    dt.Columns.Add("FirstName", typeof(System.String));
    dt.Columns.Add("Age", typeof(System.Int32));
    dt.Columns.Add("Selected", typeof(System.Boolean));
    dt.Rows.Add("rambo", 60, true);
    dt.Rows.Add("Arnie", 35, false);
    gridView1.OptionsBehavior.AutoPopulateColumns = true;
    bindingSource1.DataSource = dt;
    gridControl1.DataSource = bindingSource1;
