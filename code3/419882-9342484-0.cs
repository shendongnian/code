    private object RefineResults(ResultList<Result> results)
    {           
      // results has three properties: Summary, QueryDuration, and List
      var refined = results.Select(x => new
      {
        x.ID, x.FirstName, x.LastName
      });
    
      return new { Results = refined, Summary = results.Summary, QueryDuration = results.QueryDuration };
    }
