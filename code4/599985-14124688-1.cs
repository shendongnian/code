    [TestMethod]
    async public Task CreateThumbnail_EmptyLayout_ReturnsEmptyGrid()
    {
        int count = 0;
        await ExecuteOnUIThread(() =>
        {
            Layout l = new Layout();
            ThumbnailCreator creator = new ThumbnailCreator();
            Grid grid = creator.CreateThumbnail(l, 192, 120);
            count = grid.Children.Count;
        });
        Assert.AreEqual(count, 0);
    }
    public static IAsyncAction ExecuteOnUIThread(Windows.UI.Core.DispatchedHandler action)
    {
        return Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, action);
    }
