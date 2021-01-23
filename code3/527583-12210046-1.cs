            [HttpPost]
        public ActionResult AddVacancy(VacancyViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _serviceClient.AddVacancy(viewModel);
                viewModel.SavedSuccessfully = true;
            }
            return Json(viewModel);
        }
