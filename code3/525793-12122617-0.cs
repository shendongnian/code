    public ActionResult Users() {
        IEnumerable<UserModel> model = from MembershipUser u in Membership.GetAllUsers()
                    select new UserModel {user = u, roles = Roles.GetRolesForUser(u.UserName)};
    
        return View(model);
    }
