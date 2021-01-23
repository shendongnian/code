            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,FirstName,LastName,Phones")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                //TODO need to update this to accept phone numbers
                return RedirectToAction("Index");
            }
            return View(contact);
        }
How do you add and remove them on the page? Add some buttons, bind some JavaScript, add a method to the controller that will return a view for that model. Ajax back to grab it and insert it into the page. I'll let you work out those details, as it's just busy work at this point.
