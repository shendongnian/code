     public ActionResult Index()
	 {
			var model = new Model();
			model.ModelObject = new ModelObject();
			model.ModelObject.VatRatesList = new SelectList(
				new Dictionary<decimal, string>
                {
                    { 0m, string.Empty },
                    { 1.2m, "20%" },
                    { 1m, "0%" }
                }, "Key", "Value",
				model.ModelObject.VatRate ?? 0m);
			return View(model);
	 }
