    public ActionResult ShowProfile()
    {
        var model = new MyViewModel();
        model.Profile = ...
        model.Groups = ...
        return View(model);   
    }
