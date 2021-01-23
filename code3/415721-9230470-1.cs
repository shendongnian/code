    [HttpPost]
    public ActionResult Foo(FirstStepViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
    
        return RedirectToAction("Bar", new { projectname = model.ProjectName });
    }
