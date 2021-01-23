    protected void ButtonClick(object sender, WizardNavigationEventArgs e)
    {
    	if (!Page.IsValid)
    	{
    		e.Cancel = true;
    	}
    }
