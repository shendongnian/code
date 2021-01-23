    [HttpDelete]
    public PartialViewResult Delete(int id)
    {
        userManager.DeleteUser(id);
        return Json(new 
        {
            Partial = RenderPartialViewToString("UsersPartial", userManager.GetUsers()),
            StatusMessage = string.Format("User deleted ok, id: {0}", id)
        });
    }
