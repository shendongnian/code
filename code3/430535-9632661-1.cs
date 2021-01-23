        try
    {
        if (ModelState.IsValid)
        {
            db.Vehicles.Add(vehicle);
            db.SaveChanges();
        }
    }
    catch (DataException)
    {
        //Log the error (add a variable name after DataException)
        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
    } 
