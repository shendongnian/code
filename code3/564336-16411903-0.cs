        public ActionResult Save(string customerViewString)
        {
            var jsonSerializer = new JavaScriptSerializer();
            var customerViewModel = jsonSerializer.Deserialize<CustomerViewModel>(customerViewString);
            if (customerViewModel != null && ModelState.IsValid)
            {
                var customers = Repository.GetItems<Customer>();
                Repository.SaveChanges<Customer, CustomerViewModel, NorthWindDataContext>(customers, customerViewModel);
            }
            return Json(ModelState.ToDataSourceResult());
        }
