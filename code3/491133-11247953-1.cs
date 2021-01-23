        [HttpPost]
        public ActionResult SendUp(string Name, string ta)
        {
            string s = ta;
            // Process stuff here
            // Go to another action or whatever
            return RedirectToAction("Index");
        }
