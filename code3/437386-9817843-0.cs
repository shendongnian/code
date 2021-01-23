    public void Page_Load(object sender, EventArgs e ){
        gvTicketStatus.RowCommand += new EventHandler(RowCommand);
    }
    protected void gvTicketStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string compositeFiles = e.Row.Cells[3].Text;
                // split the string into individual files using delemeter "?"
                string[] fileSet = compositeFiles.Split('?');
                e.Row.Cells[3].Text = "";
                foreach (string str in fileSet)
                {
                    if (str != null)
                    {
                        // add a link button to the cell of the data grid.                                             
                        LinkButton lb = new LinkButton();
                        lb.Text = "Download File";
                        lb.CommandName = "download"; //this is useful if you need to add more links with different commands.
                        lb.CommandArgument = str;// str is file URL
                        e.Row.Cells[3].Controls.Add(lb);
                    }
                }
                
            }
        }
