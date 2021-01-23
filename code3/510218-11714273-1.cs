    public class RandomController : Controller   
    {
        protected readonly CombosContext db;
        protected RandomController (CombosContext db)
        {
            this.db = db;
        }
        ...
    }
    public class MenuController : RandomController
    {
        public MenuController (CombosContext db)
            : base (db)
        {
        }
    }
