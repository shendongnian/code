    var top5 = DownloadHistory
        // group by SongId
        .GroupBy(row => row.SongId)
        // for each group, select the newest row
        .Select(grp => 
            grp.OrderByDescending(historyItem => historyItem.DateInserted)
            .FirstOrDefault()
        )
        // get the newest 5 from the results of the per-song partition
        .OrderByDescending(historyItem => historyItem.DateInserted)
        .Take(5);
