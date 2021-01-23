    private void timerProgressBar_Tick(object sender, EventArgs e)
    {
    	if (progressBarChanges.Value == 100)
    	{
    		progressBarChanges.Value = 0;
    	}
    	progressBarChanges.PerformStep();
    }
