    protected void gvProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                string Active = "";
                if (e.Row.DataItem != null)
                { 
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        Label lblEditActive = (Label)e.Row.FindControl("lblUP_ET_ActiveStatus");
                        if (lblEditActive.Text != string.Empty)
                        {
                            Active = lblEditActive.Text.Trim();
                        }
    
                        DropDownList ddlActive = (DropDownList)e.Row.FindControl("ddlUP_ET_ActiveStatus");
                        ddlActive.Items.Clear();
                        ddlActive.Items.Add("True");
                        ddlActive.Items.Add("False"); 
                        ddlActive.DataBind(); 
                        ddlActive.Items.FindByText(Active).Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
