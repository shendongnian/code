        [HttpPost]
        public ActionResult Edit(Table1 table1)
        {
            var query = RouteData.Values["name"];
            var back = "../job/" + query;
            if (ModelState.IsValid)
	        {
		        _db.Entry(table1).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
                return RedirectPermanent(back);
	        }
            return View(table1);
        }
