    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView gv = (sender as GridView);
                DataListItem DLItem= (DataListItem)gv.NamingContainer;
                //Label Id = (Label)DLItem.FindControl("lblId");
    
                gv.PageIndex = e.NewPageIndex;
              
                //Your gridbinding code
        HiddenField hdn = (HiddenField)DLItem.FindControl("hdnCountryID");
        //GridView grd = (GridView)e.Item.FindControl("grdDetails");
        objCountries = new Countries();
        lstCountries = objCountries.getallCountries();
        gv .DataSource = lstCountries ;//lstOrders;
        gv .DataBind();
    
            }
            catch (Exception ex)
            {
    
               // return;
            }
    
        }
