    [HttpPost]
    public ActionResult Edit(BlogPostViewModel model)
    {
     if(ModelState.IsValid)
     {
       var domainObject=new blog_Post();
       domainObject.Title=model.Title;
       domainObject.ModifiedDate=DateTime.Now;
       //set other properties also
  
       repo.Update(domainObject);
       return RedirecToAction("Success");
     }
     return View(model);
    }
