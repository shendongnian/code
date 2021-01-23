    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                   e.Row.Enabled=false;//Check on the condition that uploaded is completed            
            }
        }
