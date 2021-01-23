    public ActionResult StudentName(int studentId)//you can't pass a model object to a get request
    {
            var model = new StudentModel();
            using (var db = new SchoolDataContext())
            {
                //fetch your record based on id param here.  This is just a sample...
                var result = from s in db.Students
                             where s.id equals studentId 
                             select s.StudentName.FirstOrDefault();
                model.StudentName = result.ToString();
            }
         return View(model);
    }
