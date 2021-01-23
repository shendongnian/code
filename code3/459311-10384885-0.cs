    GridView1.RowCommand += GridView1_RowCommand;
    private void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
    		if (e.CommandName == "Select")
    		{
    			int index = Convert.ToInt32(Convert.ToString(e.CommandArgument));
    			GridViewRow row = GridView1.Rows[index];
    			this.NameTextBox.Text = Server.HtmlDecode(row.Cells[1].Text);
    
    		}
    
    }
