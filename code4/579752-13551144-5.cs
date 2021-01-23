    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            Database = new DatabaseContext();
        }
        protected DatabaseContext Database { get; set; }
        protected override void Dispose(bool disposing)
        {
            Database.Dispose();
            base.Dispose(disposing);
        }
    }
