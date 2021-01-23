    [HttpPost]
    public ActionResult Save(Model model)
    {
        if (!ModelState.IsValid)
            return View(model);
        Result result = saveModel(result)
        if (Result.Status == Status.SUCCESS)
            return RedirectToAction("Index");
        if (Result.Status != Status.FAILURE)
        {
            ModelState.AddModelError("", "Ooops, failed");
        }
        else
        {
            ModelState.AddModelError("", "Some other error");
        }
        return View(model)
    }
