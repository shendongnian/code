        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(UnitContract unitContract)
        {
            // do your business here .... unitContract.Id has a value at this point
            return View();
        }
