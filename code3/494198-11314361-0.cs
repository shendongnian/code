    protected void btnSubmit_Click(object sender, EventArgs e)
    {
    	try
    	{
    		if (rbtnSearchBy1.Checked)
    		{
    			Server.Transfer("ViewEmpHistory.aspx");
    		}
    		if (rbtnSearchBy2.Checked)
    		{
    			Server.Transfer("SearchEmp.aspx");
    		}
    		if (rbtnSearchBy3.Checked)
    		{
    			Server.Transfer("ViewEmpCard.aspx");
    		}
    	}
    	catch(Exception ex)
    	{
    		Trace.Warn("Exception Caught", "Exception: btnSubmit_Click", ex);
    	}
    }
