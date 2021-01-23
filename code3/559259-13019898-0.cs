    [HttpPost]
    public ActionResult Delete(UserDisplayModel model)
    {
        Membership.DeleteUser(model.User.UserName);
    }
