    if (ModelState.IsValid)
    {
        taskOld = dbContext.Tasks.Single (t => t.ID == task.ID);
        // ... Some code ...
        // taskOld is already attached to the DbContext, so just map the updated
        // properties.
        taskOld.Property1 = task.Property1;
        taskOld.Property2 = task.Property2;
        ...
        db.SaveChanges();
        return RedirectToAction("Index", "Task", new { id = task.orderID });
    }
