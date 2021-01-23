        [HttpGet]
        [ChildActionOnly]
        public ActionResult DQuantities(int id = 0)
        {
           
            General_Info general_info = unitOfWork.General_Info_Repository.GetByID(id);
            IEnumerable<Quantity> quantities = db.Quantitys.Where(q => q.General_InfoQuotesID == general_info.QuoteID);
            return PartialView(quantities);
        }
