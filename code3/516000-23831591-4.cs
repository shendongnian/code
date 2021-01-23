    // GET /api/books?author=tolk&title=lord&isbn=91&somethingelse=ABC&date=1970-01-01
    public string GetFindBooks([FromUri]BookQuery query, [FromUri]Paging paging)
    {
      // ...
    }
    
    public class Paging
    {
      public string Sort { get; set; }
      public int Skip { get; set; }
      public int Take { get; set; }
    }
