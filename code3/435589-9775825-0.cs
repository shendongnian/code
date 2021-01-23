        if (ModelState.IsValid)
        {
            data.Id = 1; //EF need to know which row to update in the database.
	        db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
