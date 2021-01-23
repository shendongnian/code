                       var viewModels = from job in ObjectContext.RXS_RxJobs
                        SqlFunctions.DateDiff("Day", RXS_OrderDate,DateTime.Now) == 1
                        group job by new { RXS_ACCN, OrderDate} into jobGroup
                        select new OrderOverViewModel
                        { 
                           Quantity = jobGroup.Count(),
                           ACCN =  jobGroup.Key.RXS_ACCN,
                           OrderDate = jobGroup.Key.OrderDate
                        } ;
                        
