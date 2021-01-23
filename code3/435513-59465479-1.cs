    // GET: Vehicle/Edit/5
        public ActionResult Edit(int id,string previous)
        {
                var model = this.UnitOfWork.CarsRepository.GetAllByCarId(id).FirstOrDefault();
                var viewModel = this.Mapper.Map<VehicleViewModel>(model);//if you using automapper
		//or by this code if you are not use automapper
		var viewModel = new VehicleViewModel();
                
		if (!string.IsNullOrWhiteSpace(previous)
                    viewModel.ReturnUrl = previous;
                else
                    viewModel.ReturnUrl = "Index";
                return View(viewModel);
            }
	[HttpPost]
        public IActionResult Edit(VehicleViewModel model, string previous)
        {
                if (!string.IsNullOrWhiteSpace(previous))
                    model.ReturnUrl = previous;
                else
                    model.ReturnUrl = "Index";
                ............. 
		        .............
                return RedirectToAction(model.ReturnUrl);
        }
