    [HttpPost]
    public ActionResult Create(ProductModel model, IEnumerable<HttpPostedFileBase> files)
    {
        try
        {
            if (ModelState.IsValid)
            {
                foreach (var file in files)
                {
                    // Verify that the user selected a file
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the filename
                        var fileName = Path.GetFileName(file.FileName);
                        // etc.
                    }
                }
            }
            return RedirectToAction("Index");
        }
        catch
        {
            return View(model);
        }
    }
