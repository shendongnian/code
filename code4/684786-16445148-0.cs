    if (user != null)
                    query = query.Where(item => item.User.Id == user.Id);
                else if (equipment != null)
                    query = query.Where(item => item.User.Id < 0 && item.User.Id > 1); 
  
