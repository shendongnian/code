    public abstract class BaseController : Controller
    {
        public BaseController() { }
        private DatabaseContext _database;
        protected DatabaseContext Database
        {
            get
            {
                if (_database == null)
                    _database = new DatabaseContext();
                return _database;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (_database != null)
                _database.Dispose();
            base.Dispose(disposing);
        }
    }
