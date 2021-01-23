    public ActionResult Delete(int StuID)
        {
            if (StuID > 0)
            {
                var studata = stu.Studs.Where(x => x.StudId == StuID).FirstOrDefault();
                if (studata != null)
                {
                    stu.DeleteObject(studata);
                    stu.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    
