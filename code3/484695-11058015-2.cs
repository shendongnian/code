    void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        try
        {
            //fetch the data
            this.OnUIThread(() =>
            {
                performanceProgressBar.Visibility = Visibility.Collapsed; // This code will be performed on the UI thread -- in your case, you can update your progress bar etc.
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    } 
