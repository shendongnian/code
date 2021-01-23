    public class MyBaseController : Controller {
        .........
        private static MyDbContext _database;
        public static MyDbContext database {
            get {
                if (_database == null) {
                    _database = new MyDbContext();
                }
                return _database;
            }
        }
    }
