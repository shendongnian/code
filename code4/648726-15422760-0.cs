    container.RegisterInitializer<ImageViewer>(viewer =>
    {
        foreach (var plugin in viewer.Plugins)
        {
            plugin.Viewer = viewer;
        }
    });
