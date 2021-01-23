    var result = stockcheckItem in MDC.StockcheckItems
    	.Where(item => distinctJobs.Contains(item.JobId))
    	.GroupBy(item => new { item.JobId, item.JobData.EngineerId })
    	.AsEnumerable() //switch from Linq-to-sql to Linq-to-objects
    	.Select(job => new StockcheckJobsModel.StockcheckJob()
    	{
    		JobId = job.Key.JobId,
    		Date = MJM.GetOrCreateJobData(job.Key.JobId).CompletedJob.Value,
    		Engineer = (EngineerModel)job.Key.EngineerId,
    		MatchingLines = job.Count(sti => sti.Quantity == sti.ExpectedQuantity),
    		DifferingLines = job.Count(sti => sti.Quantity != sti.ExpectedQuantity)
    	})
    	.Orderby(item => item.Date)
        .ToList()
