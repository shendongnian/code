    [HttpPost]
    public ActionResult StudentName(StudentModel model)
    {
         if(ModelState.IsValid)
         {
            using (var db = new SchoolDataContext())
            {
                //update your db record
            }
            return RedirectToAction("Index");
         }
         return View(model);
       
    }
