    public class BaseController : Controller
    {
        private ILog _log;
        private Repository _db;
        protected Repository Db
        {
            get
            {
                return _db ?? (_db = new Repository(User));
            }
        }
        protected ILog Log
        {
            get
            {
                return _log ?? (_log = LogManager.GetLogger(this.GetType()));
            }
        }
    }
