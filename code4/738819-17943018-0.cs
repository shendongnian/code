    [HttpPost, ActionName("Index")]
    public ActionResult PostValues(CrossFieldValidation model1)
    {
        if (!ModelState.IsValid)
        {    
            return View(model1);
        }
    }
