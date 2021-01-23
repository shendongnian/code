    private void emailVideoButton_Click(object sender, EventArgs e)
    {
        VideoEMailForm emailForm = null;
        try
        {
            emailForm = new VideoEMailForm();
            emailForm.ShowDialog();
        }
        finally
        {
            if (emailForm != null) 
            {
                ((IDisposable)emailForm).Dispose();
            }
        }
    }
