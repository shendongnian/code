    protected void tmr_Tick(object sender, EventArgs e)
    {
        tmr.Enabled = false;
        GetInformation();        
        loadingIndicator.Style.Add("display", "none");
    }
