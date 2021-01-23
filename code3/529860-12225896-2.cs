    protected void GridViewParent_RowDataBound(Object sender, GridViewRowEventArgs e)
    {           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
              ActivityGrid ActivityGrid1= (ActivityGrid )e.Row.FindControl("ActivityGrid1");                    
                    if (ActivityGrid1 != null)
                    {
                        GridView gridView1 = (ActivityGrid )ActivityGrid1 .FindControl("gridView1");    
                        gridView1.DataSource = SomeMethodToReturnDataSource();                          
                        gridView1.DataBind();
                    }
             }          
    }
