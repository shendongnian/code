     public class CreateController : Controller
        {
            CreateRepository CreateRepository = new CreateRepository();
    
            public ActionResult Index()
            {
                var ListOfAllUserNames = CreateRepository.GetAllUserNames();
      
                // etc etc 
                return View();
            }
