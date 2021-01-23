    private void OnResolveSource(object sender, ResolveSourceEventArgs e)
    {
        if (!File.Exists(e.LocalSource) && !string.IsNullOrEmpty(e.DownloadSource))
            e.Result = Result.Download;
    }
