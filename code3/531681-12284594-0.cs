    [HttpPost]
    public ActionResult Register(NewUserViewModel newUser)
    {
        if (!ModelState.IsValid)
            return View(newUser);
        var newUserDTO = Mapper.Map<NewUserViewModel, NewUserDTO>(newUser);
        var userDTO = UserManagementService.RegisterUser(newUserDTO);
        var result = Mapper.Map<UserDTO, UserViewModel>(userDTO);
        TempData.Add("RegisteredUser", result);
        return RedirectToAction("RegisterSuccess");
    }
