     public void BindGridList(object sender, EventArgs e)
        {
            try
            {
                using (CompMSEntities1 CompObj = new CompMSEntities1())
                {
                    DateTime Start = Convert.ToDateTime(txtStart.Text);
                    DateTime End = Convert.ToDateTime(txtEnd.Text);
                    Int32 Department = Convert.ToInt32(ddlDept.SelectedValue);
                    Int32 Category = Convert.ToInt32(ddlCategory.SelectedValue);
                    Int32 Priority = Convert.ToInt32(ddlPriority.SelectedValue);
                    Int32 Status = Convert.ToInt32(ddlStatus.SelectedValue);
                    GridViewComplaintReport.DataSource = CompObj.SP_ManageComplaint_Summary(Start, End, Department, Category, Priority, Status);
                    SP_ManageComplaint_Summary_Result obj = new SP_ManageComplaint_Summary_Result();
                    GridViewComplaintReport.DataBind();
                    GridViewComplaintReport.Visible = true;
                    ExportTable.Visible = true;
                    TableGrid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblException.Text = "Problem in data retrive from database .";
                lblException.Visible = true;
                ErrorHandler.WriteError(ex.ToString());
            }
    
    
    
   
