    [HttpPost]
    public ActionResult Index(IEnumerable<ViewPerm> viewperms)
    {
        if (ModelState.IsValid)
        {
            foreach (ViewPerm viewperm in viewperms)
            {
                db.Entry(viewperm).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        return View(viewperms);
    }
