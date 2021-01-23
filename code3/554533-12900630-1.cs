    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
            if (Session["dtInSession"] != null)  
               dt1 = (DataTable)Session["dtInSession"];
           Int32 index = GridView1.SelectedIndex;
           dt1 = dt1.Rows[index].Delete();
           dt1.AcceptChanges();
           Session["dtInSession"] = dt1;  //Saving Datatable To Session   
           GridView1.DataSource = dt1;                         
           GridView1.DataBind();   
    }
