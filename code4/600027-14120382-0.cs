    public ActionResult DoSomething() {
        MyViewModel model = new MyViewModel();
        model.SomeProperty = "This property needs to be changed into the View.";
        
        return PartialView("MyPartialView", model);
    }
