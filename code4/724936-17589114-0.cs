    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(EditViewModel viewModel)
    {
         if (!ModelState.IsValid)
         {
              return View(viewModel);
         }
    
         Customer customer = Mapper.Map<Customer>(viewModel);
         customerService.Edit(customer);
         return RedirectToAction("List");
    }
