        protected void Application_RowCommand(Object sender, CommandEventArgs e)
        {
            if (e != null)
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument, CultureInfo.InvariantCulture);
                string applicationID = (((System.Web.UI.WebControls.Literal)grdApplications.Rows[rowIndex].Cells[1].Controls[1]).Text).Trim();
                string lastChangeTimeString = (((System.Web.UI.WebControls.HiddenField)grdApplications.Rows[rowIndex].Cells[1].Controls[3]).Value).Trim();
 
                DateTime lastChangeTime = Convert.ToDateTime(lastChangeTimeString);
 
            }
        }
