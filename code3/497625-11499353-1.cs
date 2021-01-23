        [HttpPost]
        public ActionResult Edit(Hour hour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WeekID = new SelectList(db.Weeks, "WeekID", "WeekID", hour.WeekID);
            ViewBag.Projects = db.Projects.ToList();
            ViewBag.Activities = db.Activities.ToList();
            return View(hour);
        }
