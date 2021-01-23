            [HttpPost]
        public ActionResult Edit(int id, AuditScheduleEdit viewModel)
        {            
            if (ModelState.IsValid)
            {
                var addGlassCutting = new SqlParameter("@AuditScheduleID", id);
                _db.Database.SqlCommand
                ("EXEC AddGlassCutting @AuditScheduleID", addGlassCutting);
                viewModel.PopulateCheckBoxsToSpacerType();
                _db.Entry(viewModel.AuditScheduleInstance).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Audit", new {id});
            }
            else
            {
                return View(viewModel);
            }
        }
