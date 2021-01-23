    [HttpPost]
    public ActionResult Search(SearchModel searchModel)
    {
       if (ModelState.IsValid)
       {
          //Search
       }
       else
       {
           return View(searchModel);
       }
    }
