       protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
       {
            if (e.CommandName=="MyCommand")
            {    
                 int row = int.Parse(e.CommandArgument.ToString());
                 var cellText= gvOwner.Rows[row].Cells[1].Text.Trim();
            }
       }
