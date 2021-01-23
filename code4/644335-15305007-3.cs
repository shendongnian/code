    public ActionResult GetBlogs()
    {
        var someService = new FooService();
        var blogs = someService.GetMeMyBlogs();
        return View("bloglist", blogs.Select(x => x.ToBlogVM())); 
    }
Which passes a list of BlogVM objects to your view.
