    public ActionResult RawValues(int pk) 
    {
        var rawValuesVM = new ViewModels.RawValuesEditingViewModel();
        try
        {
            rawValuesVM.LoadModelFieldsFromDataObject(pk);
        }
        catch (Exception ex)
        {
            // however you wish to handle a bad lookup
        }
        return View(rawValuesVM);
    }
    
    [HttpPost]
    public ActionResult RawValues(ViewModels.RawValuesEditingViewModel rawValuesVM, int pk)
    {
        if (ModelState.IsValid)
        {
            try
            {
                rawValuesVM.ExecuteRawValuesUpdate(pk);
                // Redirect or something here.
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex);
            }
        }
        return View(rawValuesVM);
    }
