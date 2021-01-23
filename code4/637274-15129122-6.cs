    [HttpPost]
    public JsonResult GetDetails()
            {
                CustomerDAL customer = new CustomerDAL();
                IList<Customer> custList = customer.GetDetail();
                return Json(custList);
            }
