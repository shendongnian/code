    public ActionResult GetBlogs()
    {
        var someService = new FooService();
        var blogs = someService.GetMeMyBlogs();
        return View("bloglist", blogs); 
    }
