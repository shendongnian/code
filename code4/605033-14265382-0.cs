      protected void btnAddName_Click(object sender, EventArgs e)
      {
        DataTable dt = GetSourceData();  
        //DataTable that you originally bind to Gridview      
        DataRow _dr = dt.NewRow();
        _dr["lblName"] = txtName.Text;
        dt.Rows.Add(_dr);
        gvName.DataSource = dt;
        gvName.DataBind();
     }
