    public class BooksController : ApiController
      {
        // GET /api/books?author=tolk&title=lord&isbn=91&somethingelse=ABC&date=1970-01-01
        public string GetFindBooks([FromUri]BookQuery query)
        {
          // ...
        }
      }
    
      public class BookQuery
      {
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string SomethingElse { get; set; }
        public DateTime? Date { get; set; }
      }
