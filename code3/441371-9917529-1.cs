     [HttpPost]
     public ActionResult ResetPassword(Guid secureID, ResetPasswordModel model)
     {
       if(ModelState.IsValid)
       {
          // Validation correct, Lets save the new password and redirect to another action
       }
       return View(model);
     }
