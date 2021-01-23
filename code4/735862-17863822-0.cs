      public class WordsController : ApiController
        {
            // GET api/<controller>
            public IEnumerable<Keyword> Get()
            {
                using (TestDataContext dc = new TestDataContext())
                {
                    return dc.Keywords;  //deferred execution
                }
        
            }
        } //too late to materialize the query.  The context has been disposed
