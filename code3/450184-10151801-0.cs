    protected void RecordsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
        
                        e.Row.Attributes.Add("onmouseover","checkbox.style.display='block'");
                        e.Row.Attributes.Add("onmouseout", "checkbox.style.display='none'");
                    }
                }
                  
                    
                
                
               
            
        
