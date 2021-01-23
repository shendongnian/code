    [Authorize]
    [HttpPost]
    public ActionResult Profile(designer thisDesigner)
    {
        if (ModelState.IsValid)
        {
            db.Entry(thisDesigner).State = System.Data.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View(thisDesigner);
            }
        }
        return RedirectToAction("Profile");
    }
