    public void SomeThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        /* Update progress bar */
        ProgressBar.Value = (e.ProgressPercentage);
        if (e.UserState != null)
        {
            TextBox.Text += (string)e.UserState;
        }
    }
