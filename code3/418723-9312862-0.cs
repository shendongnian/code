    public ActionResult Contact()
    {
        var model = new ContactUsViewModel
        {
            SuccessMessage = TempData["SuccessMessage"] as string
        };
        return View(model);
    }
    [HttpPost]
    public ActionResult Contact(ContactUsViewModel model)
    {
        if (ModelState.IsValid)
        {
           bool isSuccess = _siteService.CreateInquiry(model.Inquiry);
           if (isSuccess)
           {
               TempData["SuccessMessage"] = "Thank you for contacting us.";
               return RedirectToAction("Contact");
           }
        }
    
        // since you are modifying the value of the InquiryTypes property
        // you need to remove it from the modelstate to avoid getting the 
        // old value rendered by the helpers
        ModelState.Remove("InquiryTypes");
        model.InquiryTypes = InquiryTypes;
        return View(model);
    }
