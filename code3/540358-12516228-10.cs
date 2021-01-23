    StockcheckJobs =
         from stockcheckItem in MDC.StockcheckItems
         where distinctJobs.Contains(stockcheckItem.JobId)
         group stockcheckItem by new { stockcheckItem.JobId, stockcheckItem.JobData.EngineerId } into jobs
         select As.Enumerable into localJobs // MAGIC!
         let date = MJM.GetOrCreateJobData(localJobs.Key.JobId).CompletedJob.Value
         orderby date descending 
         select new StockcheckJobsModel.StockcheckJob()
         {
             JobId = localJobs.Key.JobId,
             Date = date,
             Engineer = new ThreeSixtyScheduling.Models.EngineerModel() { Number = localJobs.Key.EngineerId },
             MatchingLines = localJobs.Count(sti => sti.Quantity == sti.ExpectedQuantity),
             DifferingLines = localJobs.Count(sti => sti.Quantity != sti.ExpectedQuantity)
         };
