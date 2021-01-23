    protected void Page_Load(object sender, EventArgs e)
    {
    	foreach (DataPoint dp in this.Chart1.Series["YourSeriesName"].Points)
    	{
    		dp.PostBackValue = "#VALX,#VALY";
    	}
    }
    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {
    	string[] pointData = e.PostBackValue.Split(',');
    	// Add click event code here
    }
