    [HttpPost]
    public HttpResponseMessage ResetPassword(UserViewModel userModel)
    {
        User user = Mapper.Map<UserViewModel, User>(userViewModel);
        _userService.ResetPassword(user, userModel.CreatedBy, userModel.AppId, userModel.TimeoutInMinutes);
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
