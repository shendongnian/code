    private async void InstallApp(string name, Uri uri)
    {
        try
        {
            StatusTextBlock.Text = "Installing app";
            var installTask = InstallationManager.AddPackageAsync(name, uri);
            installTask.Progress = (installResult, progress) => Dispatcher.BeginInvoke(() =>
            {
                StatusTextBlock.Text = "Progress: " + progress;
            });
            var result = await installTask;
            StatusTextBlock.Text = "Done: " + result.InstallState.ToString();
        }
        catch (Exception ex)
        {
            StatusTextBlock.Text = "Failed to install: " + ex.Message;
        }
    }
