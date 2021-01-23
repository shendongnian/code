    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        lblDateCal.Text = DateTime.Today.AddMonths(-1).ToString("MMMM");
    }
    
    protected void btnNext_Click(object sender, EventArgs e)
    {
        lblDateCal.Text = DateTime.Today.AddMonths(+1).ToString("MMMM");
    }
