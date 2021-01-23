    protected void tmr_Tick(object sender, EventArgs e)
    {
        tmr.Enabled = false;
        // show a loading indicator
        GetInformation();        
        // Hide the loading indicator 
    }
