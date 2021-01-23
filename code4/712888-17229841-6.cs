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
                   Statuses = statusService.GetAll(),
                   StatusId = 4 // Set the default value
              };
    
              return View(viewModel);
         }
    }
