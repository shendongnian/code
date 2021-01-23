    public ActionResult Create(Book book, HttpPostedFileBase file)
    {
        if (ModelState.IsValid)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        ViewBag.CreatedBy = new SelectList(db.Users, "ID", "UserName", book.CreatedBy);
        return View(book);
    }
