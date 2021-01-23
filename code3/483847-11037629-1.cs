    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    
     if (e.Row.RowType == DataControlRowType.DataRow)
         {
                DataRow row = ((System.Data.DataRowView)e.Row.DataItem).Row;
                HyperLink hlink = e.Row.FindControl("HL") as HyperLink;
                if (hlink!=null)
                {
                    string url = string.Format("~/Docs/{0}",row["FileName"]);
                    hlink.NavigateUrl = url;
                    hlink.Text = "Read";
                }
         } 
    }
