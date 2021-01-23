    [HttpPost]
    public ActionResult MyAction(MyViewModel model, HttpPostedFileBase document)
    { 
        if (document != null && document.ContentLength > MAX_ALLOWED_SIZE)
        {
            ModelState.AddModelError("document", "your file size exceeds the maximum allowed file size")
            return View(model);
        }
        ...
    }
