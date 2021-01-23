    [HttpPost]
    [AllowAnonymous]
    public JsonResult ApiLogIn(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var outcome = _authService.LogIn(model);
    
            if (outcome == LogInOutcome.Success)
            {
                return Json(new { }); // Empty on success
            }
            else
            {
                Context.Items["AjaxPermissionDenied"] = true;
                return Json(new { reason = outcome.ToString() });
            }
        }
    
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new { }); // Empty or invalid model
    }
