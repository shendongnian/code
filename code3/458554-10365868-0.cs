    private void FDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        // intercept form closing from Close box in title bar
        if (e.CloseReason == CloseReason.UserClosing)
            {
                 e.Cancel = !ConfirmFormExit();
            }
    }
