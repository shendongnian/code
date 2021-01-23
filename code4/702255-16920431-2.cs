    private void emailVideoButton_Click(object sender, EventArgs e)
    {
        using (VideoEMailForm emailForm = new VideoEMailForm())
        {
            emailForm.ShowDialog();
        }
    }
