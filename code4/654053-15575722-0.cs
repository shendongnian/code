    public class MyController : ApiController
    {
        private DbContext _db = new DbContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
