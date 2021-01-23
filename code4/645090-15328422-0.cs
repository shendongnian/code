    private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
    {
        Debug.WriteLine("e.MaximumProgress " + e.MaximumProgress);
        progressBar1.Maximum = (int)e.MaximumProgress;
        Debug.WriteLine("e.CurrentProgress " + e.CurrentProgress);
        progressBar1.Value = (int)e.CurrentProgress;
    }
