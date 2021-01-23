    private void PrintVideoList(IEnumerable<string> sortColumns, ListSortDirection sortOrder)
    {
        var videos = this.GetVideos();
        var sortedVideos = videos.AsQueryable();
        foreach (var sortColumn in sortColumns.Reverse())
        {
            sortedVideos = sortedVideos.OrderBy(sortColumn, sortOrder);
        }
        // Test the results
        foreach (var video in sortedVideos)
        {
            Console.WriteLine(video.Title);
        }
    }
