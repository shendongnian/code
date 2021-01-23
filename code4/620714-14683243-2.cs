    private void OnTimedEvent(object sender, EventArgs e)
    {
        if (SynchronizationContext.Current != uiContext)
        {
            uiContext.Post(delegate { EnableMenuAndButtons(sender, e); }, null);
        }
        else
        {
            // Do your normal stuff here
            CheckStatus(); // this function will update my UI base of information will receive from serial port 
        }
    }
            
}
