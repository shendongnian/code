    public ActionResult MyActionMethod()
    {
         MyViewModel viewModel = new MyViewModel
         {
              // Database call to return paths
              UploadedFiles = fileService.GetFiles()
         };
    
         return View(viewModel);
    }
