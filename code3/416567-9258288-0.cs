    public ActionResult Index(string url)
    {
         var pageTitle = url.Split('/')[0];
         var page = Services.PageService.GetPage(pageTitle);
    
         if (page == null)
         {
            return new HttpNotFoundResult();
         }
          return View(page);
     }
