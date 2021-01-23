    [HttpPost]
    public ActionResult Edit(EditPersonModel model)
    {
        // .. Your code to edit the person ..
        TempData["message"] = "The person has been updated.";
        return RedirectToAction("Index", "People");
    }
