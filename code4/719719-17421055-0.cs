    public ActionResult GetAllUsers()
    {
         List<User> users = userService.FindAll();
    
         var result =
              from user
              in users
              select new[]
              {
                   user.Id.ToString(),
                   user.FirstName,
                   user.LastName,
                   user.Age.ToString()
              };
    
              return Json(result, JsonRequestBehavior.AllowGet);
    }
