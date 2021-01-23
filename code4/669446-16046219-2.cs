        [HttpGet]
        [ChildActionOnly]
        public ActionResult DQuantities(int id = 0)
        {
            General_Info general_info = unitOfWork.General_Info_Repository.GetByID(id);
            IEnumerable<Quantity> getQuantities = unitOfWork.Quantity_Repository.Get();
                
            IEnumerable<Quantity> qtys = getQuantities.Where(q => q.General_InfoQuotesID == general_info.QuoteID);
            return PartialView(qtys);   
        }
