     public ActionResult Edit(Int32 StuID)
        {
            var studata = stu.Studs.Where(x => x.StudId == StuID).FirstOrDefault();
            if (studata != null)
            {
                TempData["ID"] = StuID;
                TempData.Keep();
                return View(studata);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Stud stu1)
        {
            Int32 StuID = (int)TempData["ID"];
            var studata = stu.Studs.Where(x => x.StudId == StuID).FirstOrDefault();
            studata.StudName = stu1.StudName;
            studata.StudAddress = stu1.StudAddress;
            studata.StudEmail = stu1.StudEmail;
            stu.ObjectStateManager.ChangeObjectState(studata,);
            stu.SaveChanges();
            return RedirectToAction("Index");
        }
