    public class RandomController : Controller   
    {
        protected readonly CombosContext db;
        ...
    }
    public class MenuController : RandomController
    {
        public MenuController ()
        {
            db = // initialise DbContext here;
        }
    }
