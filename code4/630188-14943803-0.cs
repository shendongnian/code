    [HttpPost]
        public ActionResult AnotherListEdit(IList<ClassInstanceDetail> list)
        {
            if (ModelState.IsValid)
            {
                foreach (ClassInstanceDetail editedClassInstanceDetail in list)
                {
                    var tempBook = (from teacher in db.ClassInstanceDetails
                                    where (teacher.ClassInstanceID == editedClassInstanceDetail.ClassInstanceID)
                                    && (teacher.StudentID == editedClassInstanceDetail.StudentID)
                                    select teacher).First();
    
                    db.ApplyCurrentValues(tempBook.EntityKey.EntitySetName, editedClassInstanceDetail);
                }
                db.SaveChanges();
                return View(db.Teachers.ToList());
            }
           //HERE!!!What view should return? any error messages?
            return View("View with no valid modelstate?");
    
        }
