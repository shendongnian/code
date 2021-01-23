          public User GetUserByUserNameAndPassword(string userName, string userPassword)
            {
                using (var context = DataObjectFactory.CreateContext())
                {
                 if (context.UserEntities.Any(u => u.UserName == userName && u.UserPassword == userPassword))
                 {
                    return Mapper.Map(context.UserEntities.Single(u => u.UserName == userName && u.UserPassword == userPassword));
                 }
                 else
                 {
                  //Deal with no user here through chosen method
                 }
                }
            }
