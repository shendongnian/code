    public void wc_DownloadStringCompleted(Object sender, DownloadStringCompletedEventArgs e)
    {
        if (!e.Cancelled && e.Error == null)
        {
            MessageBox.Show((string)e.Result);
        }
    }
