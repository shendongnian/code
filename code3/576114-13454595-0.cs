    [HttpPost]
    public ActionResult Create(RoleModel model)
    {
        if (ModelState.IsValid)
        {
            var role = new RoleDto
                {
                    Name = model.Name,
                    Description = model.Description
                };
            var roleAdded = _rolePermissionsRepository.AddRole(role);
            if (roleAdded != null)
            {
                //CLOSE WINDOW
				return Json(new { success = true });
            }
            else
            {
                return Json(new { error = "Error! Can't Save Data!" });
			}
        }
		
        return Json(new { error = "Generic Error Message!" });
    }
	
