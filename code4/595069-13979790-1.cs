        var uiSync = SynchronizationContext.Current;
        Task.Factory.StartNew(() =>
            {
                var client = new PlaylistExportClient(baseUrl);
                var list = client.GetPlaylistsByDateRange(...).ToList();
                uiSync.Post(() => _queueDataGridView.DataSource = list, null);
            },token,TaskCreationOptions.None,context);
