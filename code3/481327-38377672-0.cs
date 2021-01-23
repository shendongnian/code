    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                
                if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
    //----------------------------------Grid view column invisible------------------------------------------------------------
                    if (Request.QueryString.Get("show") == "all")
                        GridView1.Columns[0].Visible = true;
                    else
                        GridView1.Columns[0].Visible = false;
    
                    //-------------------------------------------------------------------------------------------------------------------------
    
    }
    
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                
                GridView1.PageIndex = e.NewPageIndex;
                gvbind();// Grid View Binded
             
            }
    
    // Source Code
    allowpaging="true" OnPageIndexChanging="Gridview1_PageIndexChanging" pagesize="2"
