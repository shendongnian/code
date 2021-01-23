        public ActionResult EmailRequest()
        {
               EmailRequest email = new EmailRequest();
               TryUpdateModel(email);
            if (ModelState.IsValid)
            {
                // save to db, for instance
                return RedirectToAction("AnotherAction");
            }
            return View();
        }
