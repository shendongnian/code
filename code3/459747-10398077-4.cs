    [HttpPost]
    public ActionResult Process(MyViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // the model is invalid => redisplay view
            return View(model);
        }
    
        // at this stage the model is valid => you could do some processing here 
        // and redirect
        ...
    }
