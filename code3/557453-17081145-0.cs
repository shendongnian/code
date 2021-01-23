    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ActionResult DeleteUser(int id)
    {
        var tmpuser = "";
        var ctx = new UsersContext();
        using (ctx)
        {
            var firstOrDefault   = ctx.UserProfiles.FirstOrDefault(us => us.UserId==id);
            if (firstOrDefault != null)
                tmpuser = firstOrDefault.UserName;
        }
    
        string[] allRoles = Roles.GetRolesForUser(tmpuser);
        Roles.RemoveUserFromRoles(tmpuser,allRoles);
        ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(tmpuser);
        Membership.Provider.DeleteUser(tmpuser, true);
        Membership.DeleteUser(tmpuser, true);
    
        ctx = new UsersContext();
    
        return View(ctx.UserProfiles.OrderBy(user => user.UserName).ToList());
    }
