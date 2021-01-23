        [HttpPost]
        public ActionResult AddSaveTreventLocationLookup(TreventModel model)
        {
            
                string acquiringInstitutionIdentificationCode;  
                string cardAcceptorIdentificationCode;
                string merchantId;
                acquiringInstitutionIdentificationCode =   model.AcquiringInstitutionIdentificationCode;
                cardAcceptorIdentificationCode = model.CardAcceptorIdentificationCode;
                merchantId = model.MerchantId;
                //
            
            return RedirectToAction("TreventLookUp");
        }
        public ActionResult TreventLookUp()
        {
            return View("TreventLookUp");
        }
    }
