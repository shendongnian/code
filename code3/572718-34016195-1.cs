      protected void btnJobAppSelected_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridViewJobApplications.Rows)
        {
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            LinkButton btnJobAppSelected = (LinkButton)GridViewJobApplications.Rows[rowIndex].FindControl("btnJobAppSelected");
   
        }
    }
