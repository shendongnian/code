    public class MyController
    {
         private readonly IStatusService statusService;
    
         public MyController(IStatusService statusService)
         {
              this.statusService = statusService;
         }
    
         public ActionResult MyActionMethod()
         {
              MyViewModel viewModel = new MyViewModel
              {
                   Statuses = statusService.GetAll()
              };
    
              return View(viewModel);
         }
    }
