    [HttpDelete]
    public ActionResult Index(MyViewModel[] model)
    {
        // simulate a validation error
        ModelState.AddModelError("", "some error occured");
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // TODO: here we do the actual delete
        return RedirectToAction("Index");
    }
