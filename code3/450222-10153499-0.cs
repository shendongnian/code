    private void UpdateDownloadLabel(string File)
    {
        if (labelDownloadProgress.InvokeRequired)
        {
            labelDownloadProgress.Invoke(new Action(() =>
                {
                    labelDownloadProgress.Text = "Downloading: " + File;
                });
        }
        else
        {
            labelDownloadProgress.Text = "Downloading: " + File;
        }
    }
