    public ActionResult Edit(Companies companies, HttpPostedFileBase file)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (file != null)
                {
                    //Do stuff with file, save changes to database etc.
                    return RedirectToAction("bgcTest2", "Companies", new { BolagsID = companies.BolagsID });
