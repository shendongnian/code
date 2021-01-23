     public ActionResult Edit(int id)
            {
                Hour hour = db.Hours.Find(id);
                ModelState.AddModelError("Name", "What a nice name");
                return View(hour);
            }
