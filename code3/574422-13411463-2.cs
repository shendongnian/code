    private void BindGridWithMergeTables()
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        dt1.Columns.Add("ID");
        dt2.Columns.Add("ID");
        DataRow dr1 = dt1.NewRow();
        DataRow dr2 = dt2.NewRow();
        dr1["ID"] = "1";
        dr2["ID"] = "2";
        dt1.Rows.Add(dr1);
        dt2.Rows.Add(dr2);
        DataTable dtAll = new DataTable();
        dtAll = dt1.Copy();
        dtAll.Merge(dt2, true);
        dataGridView1.DataSource = dtAll;
        dataGridView1.DataBind();
     
    }
