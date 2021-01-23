    [HttpPost]
     public ActionResult SubmitNew(ViewModel viewModel)
     {
         if(ModelState.IsValid)
         {
           SomeService service = (SomeService)Session["SomeService"];
           bool success = service.guestRegistration(viewModel.username, viewModel.password);
           if (success)
           {
              return RedirectToAction("Index");
           }
           ModelState.AddModelError("", "Name taken...")"
           return View(viewModel);
         }
     }
