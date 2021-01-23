    protected void GridViewParent_RowDataBound(Object sender, GridViewRowEventArgs e)
    {           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
              ActivityGrid ActivityGrid1= (ActivityGrid )e.Row.FindControl("ActivityGrid1");                    
                    if (ActivityGrid1 != null)
                    {
                        ActivityGrid1.DataSource = SomeMethodToReturnDataSource();                       
                        ActivityGrid1.DataBind();
                    }
             }          
    }
