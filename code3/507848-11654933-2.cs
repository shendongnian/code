    public ActionResult GetCustomer(int id)
    {
       CustomerViewModel objVM=repositary.GetCustomerFromId(id);
       objVm.Address=repositary.GetCustomerAddress(id);
       objVm.Orders=repositary.GetOrdersForCustomer(id);
       return View(objVM);
    }
