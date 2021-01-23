    [HttpPost]
    public ActionResult Update(CustomerViewModel model)
    {
       Customer customer=repositary.GetCustomerFromID(model.ID)
       customer.DisplayName=model.DisplayName;
       repositary.SaveCustomer(customer);
       return RedirectToAction("ProfileUpdated");
    }
