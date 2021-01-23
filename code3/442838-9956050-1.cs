        if (id.HasValue) 
        {
            Athlete athlete = db.Athletes.Find(id.Value);
            return View(athlete);
        }
        // A null-value has been passed
        return RedirectToAction("Index");
    }
