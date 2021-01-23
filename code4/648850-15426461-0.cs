    protected void Button2_Click(object sender, EventArgs e)[convert button click event]
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Links");
        dt.Columns.Add("Status");
        dt.Columns.Add("Error");
        dt.AcceptChanges();
        DataRow dr = dt.NewRow();
        dr["Links"] = "some link";
        dr["Status"] = "status ";
        dr["Error"] = " no error";
        dt.Rows.Add(dr);
        dt.AcceptChanges();
        myListView.DataSource = dt;
        myListView.DataBind();
        //var item = string.Format("[{0}, {1} ,{2}]", TextBox2.Text );           
    }
