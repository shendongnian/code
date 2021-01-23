    protected void gvListing_RowDataBound(object sender, GridViewRowEventArgs e)
        {           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
              System.Web.UI.WebControls.LinkButton lbNewWindow= new System.Web.UI.WebControls.LinkButton();    
                    lnkbtnAdd = (System.Web.UI.WebControls.LinkButton)e.Row.FindControl("lbNewWindow");                    
                    if (lnkbtnAdd != null)
                        lnkbtnAdd.Attributes.Add("onclick","openPreview('"+ YourRefNumber + "')");
             }          
        }
