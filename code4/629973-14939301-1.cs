    public ActionResult SomeAction()
    {
        IEnumerable<MyViewModel> model = ... go query your backend
        return View(model);
    }
