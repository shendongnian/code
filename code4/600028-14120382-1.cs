    public ActionResult DoSomething(MyViewModel model) {
        
        model.SomeProperty = "This property needs to be changed into the View.";
        
        return PartialView("MyPartialView", model);
    }
