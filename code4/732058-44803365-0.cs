    var firstResults = (from qsl in firstContext.QuoteStatusLogs
                        join qs in firstContext.QuoteStatus
                        on qsl.QuoteStatusID equals (qs.QuoteStatusID)
                        where qsl.QuoteID == quoteID
                        select new
                        {
                            HistoryEvent = qsl.UpdateTime,
                            QuoteStatus = qs.Description,
                            UserGUID = qsl.EmployeeGUID,
                            Comment = qsl.Comment
                        }).ToList();
    var finalResults = (from r1 in firstResults
                        join e in secondContext.Employees
                        on r1.UserGUID equals (e.UserID)
                        orderby r1.HistoryEvent descending
                        select new QuoteStatusHistoryResult
                        {
                            HistoryEvent = r1.HistoryEvent,
                            QuoteStatus = r1.QuoteStatus,
                            User = e.FirstName + " " + e.LastName,
                            Comment = r1.Comment
                        }).ToList();
    statusHistory = new ObservableCollection<QuoteStatusHistoryResult>(finalResults);
