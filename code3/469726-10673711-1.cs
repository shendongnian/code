    var producer = new ActionBlock<someObject>(async largeFile =>
    {
        var file = await GetFileFromLargeFile(largeFile);
        if (file != null)
        {
            TotalFound++;
            await buffer.SendAsync(file);
            lblProgress.Text = String.Format("{0}", TotalFound)
        }
    }, options);
