    public class EmployeesController: Controller
    {
        private readonly IEmployeeRepository _repository;
        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
    
        public ActionResult Index()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }   
    }
