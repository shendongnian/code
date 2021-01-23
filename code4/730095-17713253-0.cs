     public ActionResult LoadUserData(){
         var model = new LoadUserDataModel();
         // code here to populate your model
         var isUserAuthenticated = MethodToFigureOutIfUserIsAuthenticated(); // returns bool
         ViewBag.isUserAuthenticated = isUserAuthenticated; // I don't like using the ViewBag so you can add this to the model if you wish.
         return View(model);
     }
