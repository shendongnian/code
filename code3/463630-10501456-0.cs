    [HttpPost]
    public ActionResult Create(ForumPost model)
    {
        if (!ModelState.IsValid)
        {
            // validation failed => redisplay the view so that the user can fix the errors
            return View(model);
        }
    
        // at this stage the model is valid => process it:
        service.CreateForumPost(model);
    
        return ...
    }
