        protected void gvListing_RowDataBound(object sender, GridViewRowEventArgs e)
        {           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
              System.Web.UI.WebControls.LinkButton lbNewWindow= new System.Web.UI.WebControls.LinkButton();    
                    lbNewWindow = (System.Web.UI.WebControls.LinkButton)e.Row.FindControl("lbNewWindow");                    
                    if (lbNewWindow!= null)
                    {
                        string YourRefNumber = DataBinder.Eval("e.Row.DataItem", "ColumnNameInDataSource").ToString();
                        lbNewWindow.Attributes.Add("onclick","openPreview('"+ YourRefNumber + "')");
                    } 
             }          
        }
