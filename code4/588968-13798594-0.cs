    protected void GV1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        string taskIds = string.Empty;
        if (e.CommandName == "edit")
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl_taskID = (Label)row.FindControl("lbl_taskID");
                     
                    if(Session["TaskID"] != null)
                      taskIds = Session["TaskID"].ToString();
                    Session["TaskID"] = taskIds + lbl_taskID.Text + ",";                 
                }
            }
            Response.Redirect("~/tasks_edit.aspx");
        }
    }
