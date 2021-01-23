    [HttpPost]
    public ActionResult Index(HomeIndexViewModel viewModel) 
            { 
        if (Convert.ToString(viewModel.startingDate) == "1/1/0001 12:00:00 AM" || Convert.ToString(viewModel.endingDate) == "1/1/0001 12:00:00 AM")  
            { 
                viewModel.startingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0); 
                viewModel.endingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59); 
            } 
 
            //There is a bunch of code here to gather all of the data need and modify the values of IndexViewModel  
 
            return View(viewModel); 
        } 
