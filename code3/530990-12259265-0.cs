    [HttpPost]
    public ActionResult Edit(int id, FormCollection form)
    {
        try
        {
            foreach(var field in form.Keys)
            {
                switch (fieldToUpper().Trim())
                {
                    case "FIELDNAME":
                        // assign value to your model property
                        break;
                }
            }
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
