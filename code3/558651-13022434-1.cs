        [Authorize(Roles = "Administrator")]
        public ActionResult SetRoles()
        {
            var model = Membership
                .GetAllUsers()
                .Cast<MembershipUser>()
                .Select(x => new SetAdminViewModel
                    {
                        UserName = x.UserName,
                        Email = x.Email,
                        Role = Roles.GetRolesForUser(x.UserName)
                    });
            return View(model);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult AddAdmin(string username)
        {
            Roles.AddUserToRole(username, "Administrator");
            return RedirectToAction("SetRoles", "Account");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult RemoveAdmin(string username)
        {
            Roles.RemoveUserFromRole(username, "Administrator");
            return RedirectToAction("SetRoles", "Account");
        }
