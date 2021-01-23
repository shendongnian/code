    protected void chkSelect_CheckedChanged
							(object sender, EventArgs e)
		{
			CheckBox chkTest = (CheckBox)sender;
			GridViewRow grdRow = (GridViewRow)chkTest.NamingContainer;
			TextBox txtname = (TextBox)grdRow.FindControl("txtName");
			
			if (chkTest.Checked)
			{
				txtname.ReadOnly = false;								
			}
			else
			{
				txtname.ReadOnly = true;								
			}
		}
