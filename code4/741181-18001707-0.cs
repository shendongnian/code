On your gvData _OnRowDataBound , check for the condition and make the appropriate buttons Visible property to false for each row.
				 protected void gvData_OnRowDataBound(object sender, GridViewRowEventArgs e)
				{
					LinkButton lbClose = (LinkButton)e.Row.Cells[5].FindControl("lbClose");
					LinkButton lbEdit = (LinkButton)e.Row.Cells[5].FindControl("lbEdit");
					LinkButton lbDelete = (LinkButton)e.Row.Cells[5].FindControl("lbDelete");
					LinkButton lbWrite = (LinkButton)e.Row.Cells[5].FindControl("lbWrite");
					
					LinkButton lbRT = (LinkButton)e.Row.Cells[5].FindControl("lbRT");
					
					if(e.Row.Cells[1].Text=="Dessert")
					{
					lbClose.Visible = false;
					lbEdit.Visible = false;
					lbDelete.Visible = false;
					}
					else
					{
					lbWrite.Visible = false;
					lbRT.Visible = false;
					}
				}
