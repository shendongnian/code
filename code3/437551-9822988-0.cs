    public ActionResult MyActionMethod()
    {
         MyViewModel viewModel = new MyViewModel
         {
              Banks = bankRepository.GetAll()
         }
         return View(viewModel);
    }
