    IEnumerable<DownloadHistory> top5Results = DownloadHistory
        // group by SongId
        .GroupBy(row => row.SongId)
        // for each group, select the newest row
        .Select(grp => 
            grp.OrderByDescending(historyItem => historyItem.DateInserted)
            .FirstOrDefault()
        )
        // get the newest 5 from the results of the newest-1-per-song partition
        .OrderByDescending(historyItem => historyItem.DateInserted)
        .Take(5);
