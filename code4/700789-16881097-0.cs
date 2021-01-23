    private bool isRestarted;
	
	private void COM_Settings_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (settingschanged && !isRestarted)
        {
		    isRestarted = true;
            Application.Restart(); //This is where only the method will be called for restart.
        }
    }
