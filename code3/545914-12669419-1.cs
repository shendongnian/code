    [Authorize]
    [HttpPost]
    public void UploadPhoto(HttpPostedFile photoFile)
    {
        if (photoFile == null)
        {
            return RedirectToAction("ErrorPage");
        }
        ...
   
        var viewModel = ...;   // but your've lost the Edit part
        return View(viewModel);
     }
