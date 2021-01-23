    public ActionResult ListOfUsers()
    {
         var users = GetUserDataRows(); // gets your collection of DataRows
         var model = new ListOfUsersViewModel
                         {
                             UsersOfList = users.Select(row = new UserViewModel { UserName = row["FirstName"], LoginName = row["UserName"] }).ToList()
                         };
         return View(model);                  
    }
