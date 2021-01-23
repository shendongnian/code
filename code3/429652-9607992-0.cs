    private void btnDailySummary_Click(object sender, EventArgs e)
    {
    	DailySummaryForm form2 = new DailySummaryForm(); 
    	this.Visible = false;
    	form2.Show();
    	form2.Closing += (sender, args) =>
    	{
    	  this.Show();
    	}
    }
