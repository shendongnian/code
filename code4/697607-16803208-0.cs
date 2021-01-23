    [HttpPost]
        public ActionResult Attendance(ViewModels.AttendanceViewModel a)
        {
            try
            {
            foreach (var j in a.Attending)
            {
                //Needed to filter by EventID here
                Attend attends = db.Attends.Where(e => e.AttendID == j.AttendID).Single();
                attends.Attended = j.Attended;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Event");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return HttpNotFound();
            }
        }
