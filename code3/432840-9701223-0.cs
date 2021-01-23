    IQueryable<Request> RequestsTotal = DataContext.Requests;
    List<Request> temp = new List<Request>();
    foreach (Request request in RequestsTotal)
                    {
    
                        RequestTransaction last = request.RequestTransactions.LastOrDefault();
    
                        if (last != null && last.ServerStatusId != 0)
                            temp.Add(request);
    
                    }
    
                    RequestsTotal = temp.AsQueryable();
