    public class HomeController : Controller
    {
        [MyFilter]
        public ViewResult Index()
        {
             //Filter will be applied to this specific action method
        }
    }
