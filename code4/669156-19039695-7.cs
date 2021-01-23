        var model = db.GetPerson(id); // get your person however you need
        return View("[Partial View Name]", model)
    }
    
    public ActionResult UpdatePersonInfo(PersonModel model)
    {
        if(ModelState.IsValid)
        {
            db.UpdatePerson(model); // update person however you need
            return Json(new { success = true });
        }
        // else
        return PartialView("[Partial View Name]", model);
    }
