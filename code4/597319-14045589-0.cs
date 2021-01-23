    [HttpPost]
    public ActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            var studentDB = db.Students.Find(id);
            db.Entry(studentDB).CurrentValues.SetValues(student);
    
            db.SaveChanges();
            Loan w = new Loan()
            {
                StudentID = student.StudentID,
                ISBN = student.ISBN.Value,
            };
            db.Loans.Add(w);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ISBN1 = new SelectList(db.Books, "ISBN", "Titulli", student.ISBN);
        return View(student);
    }
