    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
       if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                    //Add onclick attribute to select row.
                    e.Row.Attributes.Add("onclick", YourFunctionName;);
                }
    }
