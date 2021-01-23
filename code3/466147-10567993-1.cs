    [HttpPost]
    public ActionResult Edit(EditViewModel viewModel, string itemId="")
    {
        // ...
    
        RedirectToAction("Edit", new { id = itemId });
    }
