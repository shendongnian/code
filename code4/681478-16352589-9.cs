        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult Login(LoginView login)
        {    
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(kvp => kvp.Value.Errors.Select(e => e.ErrorMessage));
    
                return Json(new { success = "false", message = errors });
            }
            //Perform whatever actions you need
            // return Json(response);
        }
