    public ActionResult Index(int? pageNumber)
    {
         if(!pageNumber.HasValue)
             return Index();
         var posts = ...; // get posts
         var set = posts.Skip(pageNumber * itemsPerPage).Take(itemsPerPage);
         // or pageNumber - 1 if you want to be 1-index based
         return View(...); //or PartialView() if doing ajax, or even Json() if you want to bind on the client side
    }
