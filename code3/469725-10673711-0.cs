    var producer = new ActionBlock<someObject>(async largeFile =>
    {
        var file = GetFileFromLargeFile(largeFile);
        if (file != null)
        {
            TotalFound++;
            await buffer.SendAsync(file);
            await Task.Factory.StartNew(
                () => lblProgress.Text = String.Format("{0}", TotalFound),
                CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        }
    });
