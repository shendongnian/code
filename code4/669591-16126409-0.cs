        [HttpPost]
        public ActionResult Edit(MultiLanguageText multilanguagetext)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multilanguagetext).State = EntityState.Modified;
                foreach (var local in multilanguagetext.LocalizedTexts) db.Entry(local).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multilanguagetext);
        }
