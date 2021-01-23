    public ActionResult SomeAction()
    {
        FormsAuthentication.SetAuthCookie("test", true);    
        return RedirectToAction("FooBar");
    }
