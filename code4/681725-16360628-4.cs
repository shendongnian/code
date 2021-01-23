    [HttpPost]
    public ActionResult SomeOtherAction()
    {
        FeedViewModel model = new FeedViewModel();
        TryUpdateModel(model);
    
        if (ModelState.IsValid)
        {
            var feed = Mapper.Map<FeedViewModel, Feed>(model);
            DAL.UpdateFeed(feed);
        }
    
        return View(model)
    }
