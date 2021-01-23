      protected void li_Select_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lnkbtn.NamingContainer;
        Label lbl_ID = (Label)row.FindControl("lbl_ID");
       
      // You can fetch the data from the database on the basis of selected User ID .
        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("Product_ID");
        for (int i = 100; i <= 110; i++)
        {
            DataRow dr = dt.NewRow();
            dr["ID"] = i;
            dr["Product_ID"] = "P_" + i;
            dt.Rows.Add(dr);
        }
        // In this method you pass the id of the user, and datatable fetched from the    database of all products. or you can pass the id in the storedprocedure to get data of selected user only and then bind it here .
        GetData(lbl_ID.Text,dt);
    }
    protected void GetData(string ID, DataTable dt)
    {       
        DataView dv = dt.DefaultView;
        dv.RowFilter = "ID=" + ID;
        Gridview2.DataSource = dv;
        Gridview2.DataBind();
    }
