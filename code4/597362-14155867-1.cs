      [HttpPost]
            public ActionResult NewDirector(NewDirectorVM vm, string value)
            {
                ModelState.Clear();
                if (vm.ServiceAddress.AddressID > 0)
                {
                   //Updates the properties of the viewModel
                   vm.ServiceAddress = _Repository.GetAddress(vm.ServiceAddress.AddressID);
                }
       return View("NewDirector", vm);
    }
