        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contact= _dataSource.Contacts.FirstOrDefault(c => c.Id == id);
            
            return View(player);
        }
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dataSource.SaveContact(contact);
                    return RedirectToAction("About", "Home");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }            
            return View(contact);
        }
   
