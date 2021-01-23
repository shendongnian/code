		public ActionResult MyAction()
		{
			var viewModel = new MyModel();
			return View(viewModel);
		}
		[HttpPost]
		public ActionResult MyAction(MyModel viewModel)
		{
			bool option = viewModel.Option1;
			return View();
		}
