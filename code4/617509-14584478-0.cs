        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(YourModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }
            
            return RedirectToAction("Index");
        }
