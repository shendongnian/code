     [Authorize]
     public ActionResult AuthenticatedUsers()
     {
         return View();
     }
     [Authorize(Roles = "Role1, Role2")]
     public ActionResult SomeRoles()
     {
         return View();
     }
     [Authorize(Users = "User1, User2")]
     public ActionResult SomeUsers()
     {
         return View();
     }
