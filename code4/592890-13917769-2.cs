    [HttpGet]
    public JsonResult GetServiceAndRetailSalesDetails(Guid invoiceOrSaleId, string providerKey)
            {
    
                var items = new List<CheckOutServiceAndRetailItem>();
    
                var serviceDetails = Repository.GetAllPayableItems(invoiceOrSaleId).ToList();
    
                foreach (var s in serviceDetails)
                {
                    var item = new CheckOutServiceAndRetailItem
                    {
                        AllocationOrInvoiceOrSaleId = s.Allocation.AllocationId,
                        Name = s.Allocation.Service.Name,
                        Price = s.LatestTotal,
                        Class = s.Allocation.Service.IsAnExtra,
                    };
                    items.Add(item);
                }
    
                return Json(items, JsonRequestBehavior.AllowGet);
            }
