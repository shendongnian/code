    public class YourController : Controller
    {
         private readonly IStatusRepository statusRepository;
    
         public YourController(IStatusRepository statusRepository)
         {
              this.statusRepository = statusRepository;
         }
    
         public ActionResult YourAction()
         {
              YourViewModel viewModel = new YourViewModel
              {
                   Statuses = statusRepository.FindAll()
              };
    
              return View(viewModel);
         }
    }
