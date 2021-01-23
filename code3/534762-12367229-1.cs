    public class UsersController : Controller
    {
       private UsersContext db;
    
       protected override void Initialize(RequestContext requestContext)
       {
            base.Initialize(requestContext);
           if (Session["Database"] == null)
              db = new UsersContext("dbA");
           else
              db = new UsersContext((string)Session["Database"]);
       }
       public ViewResult Index()
       {
           if (...)       {
              db = new UsersContext("dbA");
              Session
           else
           {
              db = new UsersContext("dbB");
              Session["Database"] = "dbB";
           }
           return View(db.Users.ToList());
       }
    }
