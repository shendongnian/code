    [HttpGet]
            public ActionResult CustomerInfo()
            {
                
                var List = GetCustomerName();
                ViewBag.CustomerNameID = new SelectList(List, "CustomerId", "customerName");
                return View();
            }
