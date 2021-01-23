    [HttpPost]
    public ActionResult Create(YourViewModel viewModel)
    {
         // Check if view model is not null and handle it if it is null
         
         // Do mapping from view model to domain model
         User user = ...  // Mapping
         user.DateJoined = DateTime.Now;
         // Do whatever else you need to do
    }
