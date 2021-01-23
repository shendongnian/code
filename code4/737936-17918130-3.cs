    public class SalesController : Controller
    {
        private IOrderRepository _repository; // depend on interface
    
        // inject some implementation of dependency into controller
        public SalesController(IOrderRepository repository)
        {
           _repository = repository;
        }
    
        public ActionResult Index()
        {
            var orders = _repository.FindAll();
            return View(orders);
        }
    }
