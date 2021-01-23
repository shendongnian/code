    using (var ctx = new MyContext())    {
        results = ctx.Statements
            .Include("StatementDetails")
            .Include("StatementDetails.Entry")
            .AsQueryable();
        
        if (!string.IsNullOrEmpty(request.ItemNumber))
            results = results.Where(s => s.StatementDetails.Any(sd => sd.ItemNumber == request.ItemNumber));
        
        if (request.StatusA) {
            if (request.StatusB)
                results = results.Where(s => s.StatementStatus == StatementStatusType.StatusA || 
                                             s.StatementStatus == StatementStatusType.StatusA);
            else 
                results = results.Where(s => s.StatementStatus == StatementStatusType.StatusA);
        }
        else {
            if (request.StatusB) {
                results = results.Where(s => s.StatementStatus == StatementStatusType.StatusB);
            }
            else {
                // do nothing
            }
        }
        
        results = .Take(100)
                  .Select(s => new StatementSearchResultDTO{ ....
                  };
        
        // .. now you can you results.
    }
 
