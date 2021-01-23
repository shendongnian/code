    public class SalesConroller : Controller
    {
        private IOrderRepository _repository; // depend on interface
    
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
