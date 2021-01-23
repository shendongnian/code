    var result = dataContext.SysAccountLedger
                            .Join(dataContext.SysLogDepositsInterestMaster,
                                 a => a.cGlCode,
                                 b => b.cGlCode,
                                 (a, b) => new ListViewData
                                 {
                                     LedgerName = a.LedgerName,
                                     DateFrom = b.DateFrom,
                                     PeriodType = b.PeriodType
                                     // other properties
                                 })
                             .Where(item => item.DateFrom = Convert.ToDateTime("08-11-2012") && 
                                                item.PeriodType == "Days")
                             .ToList();
