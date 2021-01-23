    protected void Btndiag_Click1(object sender, EventArgs e)
    {
        // process database
        // verify results
        if (success)
        {
           ClientScriptManager.RegisterClientScriptBlock(this, "Btndiag_Click1", "$("#myModal").modal();", true);
        }
    }
