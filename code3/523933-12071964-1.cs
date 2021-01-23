    public ActionResult SomeAction()
    {
        MyViewModel model = ...
        return Content(model.SomePropertyThatContainsHtml, "text/html");
    }
