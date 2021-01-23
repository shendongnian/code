    public static class Helper
    {
      public static IQueryable<Table> SearchText(
        this IQueryable<Table> q,
        string searchString
      )
      {
        var searchType = -1;    
        if(searchString.IndexOf("*") == -1)
        {
            searchType = 0; // No wildcard
        }
        else if(searchString.IndexOf("*") == 0 &&
          searchString.LastIndexOf("*") == searchString.Length - 1)
        {
            searchType = 1; // start and end
        }
        else if(searchString.IndexOf("*") == 0)
        {
            searchType = 2; // ends with
        }
        else if(searchString.LastIndexOf("*") == searchString.Length - 1)
        {
            searchType = 3; // starts with
        }
        var search = searchString.Replace("*", "");
        switch(searchType)
        {
          default:
          case 0: return q;
          case 1: return q.Where( o => o.Text.Contains( search ) );
          case 2: return q.Where( o => o.Text.EndsWith( search ) );
          case 3: return q.Where( o => o.Text.StartsWith( search ) );
        }
      }
    }
