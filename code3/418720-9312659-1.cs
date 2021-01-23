    if (ModelState.IsValid)
    {
       bool isSuccess = _siteService.CreateInquiry(model.Inquiry);
       if (isSuccess)
       {
           model = new ContactUsViewModel();  // modified line
           model.SuccessMessage = "Thank you for contacting us.";
       }
    }
    model.InquiryTypes = InquiryTypes;
    return View(model);
