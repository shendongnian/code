    if (ModelState.IsValid)
    {
        DateTime now = DateTime.Now;
        if (Session["LastAdd"] == null || (now - (DateTime)Session["LastAdd"]).TotalMilliseconds > 1000)
        {
            //first time, or more than a second passed since last addition
            context.Issues.Add(issues);
            context.SaveChanges();
            Session["LastAdd"] = now;
        }
        return RedirectToAction("Index");
    }
