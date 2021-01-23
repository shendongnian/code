    private void emailVideoButton_Click(object sender, EventArgs e)
    {
        try
        {
            VideoEMailForm emailForm = new VideoEMailForm()
            emailForm.ShowDialog()
        }
        finally
        {
            if (emailForm != null) 
            {
                ((IDisposable)emailForm).Dispose();
            }
        }
    }
