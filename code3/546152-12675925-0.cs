    private void OnButtonClick(object sender, EventArgs e)
    {
        //This code happens on the UI thread
        Task.Factory.StartNew(SendEmails);
    }
    private void SendEmails()
    {
        Thread.Sleep(500);
        foreach(var email in emailAddresses) {
            SendEmail(email);
        }
    }
