    if (ModelState.IsValid)
    {
        taskOld = dbContext.Tasks.Single (t => t.ID == task.ID);
        ////some code
        // Error here! db.Tasks already contains something for the Id
        // Can't have two tasks with the same Id.  Attach doesn't update the
        // existing record, but adds the 'task' to the object graph for tracking.
        db.Tasks.Attach(task);
        db.SaveChanges();
        return RedirectToAction("Index", "Task", new { id = task.orderID });
    }
