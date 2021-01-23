    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    
    protected void litL2Sched_ResetTable(object sender, EventArgs e)
    {
        litL2Sched.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
    }
