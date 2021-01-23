    // This code is in your controller
    using  TemplateProject.Core.Entities;
    // ...
    public ActionResult HouseList()
    {
       // call method to retrieve the list of houses
       var service = new PostService();
       var houses = service.GetFullList();
       // this will render the view called "HouseList", passing it the 
       // list of houses as view model
       return View(houses)
    }
