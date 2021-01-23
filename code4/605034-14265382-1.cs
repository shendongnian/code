      protected void btnAddName_Click(object sender, EventArgs e)
      {
        DataTable dt;
        if(Session["dt"] == null)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("lblName", typeof(string)));
        }
        else
        {
            dt = (DataTable)Session["dt"];
        }
           
        DataRow _dr = dt.NewRow();
        _dr["lblName"] = txtName.Text;
        dt.Rows.Add(_dr);
        gvName.DataSource = dt;
        gvName.DataBind();
    
        Session["dt"] = dt; 
       //store dt in session so that you can reuse it again after postback
     }
