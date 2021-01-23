        public class ContentController : ApiController
    {
        private signsEntities db = new signsEntities();
        // GET api/content
        public IEnumerable<Content> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            Content[] test = this.db.Content.ToArray<Content>();
            return test;
        }
    }
