    public ActionResult CustomerInfo()
            {
                
                var List = GetCustomerName();
                ViewBag.CustomerNameID = new SelectList(List, "CustomerId", "customerName");
                ViewBag.RegisterItems = GetAllRegisterData();
                return View();
            }
    public List<CustomerModel> GetCustomerName()
            {
                // Customer DropDown
                using (dataDataContext _context = new dataDataContext())
                {
                    return (from c in _context.Customers
                            select new CustomerModel
                            {
                                CustomerId = c.CID,
                                customerName = c.CustomerName
                            }).ToList<CustomerModel>();
                }
            }
