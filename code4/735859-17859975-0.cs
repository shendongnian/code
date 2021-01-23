    public class WordsController : ApiController
    {
         private TestDataContext db = new TestDataContext();
         
         // GET api/<controller>
         public IEnumerable<Keyword> Get()
         {
             TestDataContext dc = new TestDataContext();
             return dc.Keywords;
         }
         ... other API methods
        public override void Dispose()
        {
             db.Dispose();
             base.Dispose();
        }
    }
