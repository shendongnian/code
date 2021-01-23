    [HttpPost]
    public ActionResult Delete(string userName)
    {
        Membership.DeleteUser(userName);
    }
