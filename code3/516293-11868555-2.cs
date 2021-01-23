    private void ProgressForm_Shown(object sender, EventArgs e)
    {
    	for (int i = 0; i < 101; i++)
    	{
    		calculationProgress.Value = i;
    		Application.DoEvents(); // force the form to update itself
    	}
    
    	this.Close();
    }
