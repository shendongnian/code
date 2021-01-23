    [HttpPost]
    public ActionResult Edit(tblReview tblreview, string selectedValue)
    {
        if (ModelState.IsValid)
        {
            db.Entry(tblreview).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.GameIDFK = new SelectList(db.tblGames.Where(x=>x.GameID != tblreview.GameIDFK), "GameID", "GameName");
        return View(tblreview);
    }
