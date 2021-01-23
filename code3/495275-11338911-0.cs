    protected void DataGV1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
    
            // Get the selected index 
             ViewState["SelIndex"] = e.CommandArgument.ToString();
         }
    
    protected void btnDelete_Click(object sender, EventArgs e)
    
      {
            if(ViewState["SelIndex"] == null)
                return;
    
            int selIndex = int.Parse(ViewState["SelIndex"]);
    
            dtable = (DataTable)Session["data"];
            DataRow row = dtable.Rows[selIndex ];
            dtable.Rows.Remove(row);
            DataGV1.DataSource = dtable;
            DataGV1.DataBind();
            Session["data"] = dtable;
        }
