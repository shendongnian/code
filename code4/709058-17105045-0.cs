    public class MyAppController : Controller
    {
        public FooEntities Db { get; set; }
    
        public MyAppController() 
        {
            Db = new FooEntities();
        }
    
        protected override void Dispose(bool disposing)
        { 
            this.Db.Dispose();
            base.Dispose(disposing);
        }
    }
