    from fs in context.TeleformStaging
    where !ts.IsRescan && !context.BatchesForRescan.Any(bfr=>bfr.BatchTrack == ts.BatchID)
    group ts by ts.BatchID into g
        select new
        {
            BatchID=g.Key,
            SurveyCount=g.Select (x =>x.UniqID).Distinct().Count()
        }
