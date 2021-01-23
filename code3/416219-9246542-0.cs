    var controller = kernel.Get<MyController>();
    public class MyController : Controller {
        private DbEntities _entities;
        public MyController(DbEntities entities) {
            _entities = entities;
        }
    }
