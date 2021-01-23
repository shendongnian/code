        public ActionResult ChangePass()
        {
            ChangePassword CP = new ChangePassword();
            if (TempData["status"] != null)
            {
                ViewBag.Status = "Success";
                TempData.Remove("status");
            }
            return View(CP);
        }
        [HttpPost]
        public ActionResult ChangePass(ChangePassword obj)
        {
            if (ModelState.IsValid)
            {
                int pid = Session.GetDataFromSession<int>("ssnPersonnelID");
                PersonnelMaster PM = db.PersonnelMasters.SingleOrDefault(x => x.PersonnelID == pid);
                PM.Password = obj.NewPassword;
                PM.Mdate = DateTime.Now;
                db.SaveChanges();
                TempData["status"] = "Success";
                return RedirectToAction("ChangePass");
            }
            
            return View(obj);
        }
