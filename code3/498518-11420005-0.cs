    public class ControllerBase : Controller
    {
        public ControllerBase()
            : base()
        {
            this.VerifySession();  
        }
    
        /// <summary>
        /// Indicates whether the session must be active and contain a valid customer.
        /// </summary>
        protected virtual bool RequiresActiveSession
        {
            get { return true; }
        }
            
        public void VerifySession()
        {
            if (this.RequiresActiveSession && Session["UserId"] == null)
            {
                Response.Redirect(Url.Action("LoginPage"));
            }
        }
    
    }
    
    public class HomeController : ControllerBase
    {
        protected override bool RequiresActiveSession
        {
            get
            {
                return true;
            }
        }
    
        public ActionResult Index()
        {
            return View();
        }
    }
