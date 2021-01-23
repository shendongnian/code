        public ActionResult Edit(int id)
        {
            AuditScheduleEdit viewModel = new AuditScheduleEdit();
            viewModel.AuditScheduleInstance = _db.GetAuditScheduleById(id);
            viewModel.InitializeSpacerProductCheckBoxHelperList(_db.GetAvailableSpacerProducts());
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(AuditScheduleEdit viewModel)
        {
            if(ModelState.IsValid)
            {
                viewModel.PopulateCheckBoxsToSpacerType();
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }
