    protected void lnkDeleteRisk_onclick(object sender, EventArgs e)
    {
            LinkButton obj_lnkbidtask = (LinkButton)sender;
            GridViewRow gvTask = (GridViewRow)obj_lnkbidtask.NamingContainer;
            HiddenField var_txtId (HiddenField)grdBidRisk.Rows[gvTask.RowIndex].Cells[0].FindControl("txtId");
            int int_ReturnVal = obj_WebService.DeleteRisk(var_txtId.Value);
            if (int_ReturnVal == -1)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Error occured during this operation, please contact administrator.";// "Authentication failed. Please try later.";
            }
            else
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Selected risk deleted successfully.";
                SetInitialRow();
            }
        }
