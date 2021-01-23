    var jobs = 
         (from job in (from stockcheckItem in MDC.StockcheckItems
    	    where distinctJobs.Contains(stockcheckItem.JobId)
    	    group stockcheckItem by new 
                 { stockcheckItem.JobId, stockcheckItem.JobData.EngineerId } 
             into jobs
    	    select new 
                 {
                    JobId = job.Key.JobId,
                    Engineer = (EngineerModel)job.Key.EngineerId,
                    MatchingLines = 
                        job.Count(sti => sti.Quantity == sti.ExpectedQuantity),
                    DifferingLines = 
                        job.Count(sti => sti.Quantity != sti.ExpectedQuantity)
                 }
          ).AsEnumerable()
    StockcheckJobs = jobs.Select(j => new StockcheckJobsModel.StockcheckJob
        {
             JobId = j.JobId,
             Date = MJM.GetOrCreateJobData(j.JobId).CompletedJob.Value,
             Engineer = j.EngineerId,
             MatchingLines = j.MatchingLines,
             DifferingLines = j.DifferingLines
        }).OrderBy(j => j.Date).ToList();
