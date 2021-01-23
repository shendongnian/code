        [HttpPost]
        public ActionResult Create(SomeObject object)
        {
            if (ModelState.IsValid)
            {
                //Insert code here
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
