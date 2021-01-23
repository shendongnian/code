    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView gv = (sender as GridView);
                DataListItem DLItem= (DataListItem)gv.NamingContainer;
                Label Id = (Label)DLItem.FindControl("lblId");
    
                gv.PageIndex = e.NewPageIndex;
              
                //Your gridbinding code
    
            }
            catch (Exception ex)
            {
    
               // return;
            }
    
        }
