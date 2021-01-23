    public class MyController : Controller
    {
        private readonly IMyServices _myServices;
        public AnimalController(IMyServices myServices)
        {
            _myServices = myServices;
        }
        // your actions
    } 
