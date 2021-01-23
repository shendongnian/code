        public ActionResult TestAction()
        {
            MyViewModel viewModel = new MyViewModel();
            viewModel.SomeProperty1 = "Property 1";
            viewModel.SomeProperty2 = "Property 2";
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult TestAction(MyViewModel viewModel)
        {
            return View(viewModel);
        }
