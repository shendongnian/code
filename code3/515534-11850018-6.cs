    [HttpPost]
    public ActionResult Review(MyViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // there were validation errors => redisplay the same view  
            // so that the user could fix them
            return View(model);
        }
        // at this stage we know that validation succeeded =>
        // we could proceed in processing the data and redirecting
        ...
        return RedirectToAction("CheckOut", "Financial");
    }
