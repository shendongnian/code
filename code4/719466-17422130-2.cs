    public ActionResult EmailRequest(EmailRequestViewModel viewModel)
    {
         // Check for null view model
    
         if (!ModelState.IsValid)
         {
              return View(viewModel);
         }
    
         // Do whatever you need to do
    
         return RedirectToAction("List");
    }
