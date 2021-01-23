    public ActionResult Edit(int id)
    {
      var domainObject=repo.GetPost(id);
      var viewModel=new BlogPostViewModel();
      viewModel.ID=domainObject.ID;
      viewModel.Title=domainObject.Title;
     //map other REQUIRED properties also
      return View(viewModel);
    }
