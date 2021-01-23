    using System.Data.Objects.SqlClient;
    
    var users = _usersRepository.Users.Select(u => new SelectListItem
                                        {
                                            Text = u.FirstName + " " + u.LastName,
                                            Value = SqlFunctions.StringConvert((double?)u.UserID)
                                        }
    
    return View(new MyViewModel { Users = users });
