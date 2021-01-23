        [HttpPost]
        public ActionResult Edit(ClientContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                ClientContact contact = db.ClientPersons.Include("Person")
                                        .Where(x => x.ClientPersonId == model.ClientPersonId)
                                        .SingleOrDefault();
                contact.FirstName = model.FirstName;
                // etc
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
