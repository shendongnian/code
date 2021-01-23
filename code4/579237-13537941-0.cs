    using (myEntities entities = new myEntities())
            {
                 Model.user u = entities.users.Single(m => m.emailLogon == System.Web.HttpContext.Current.User.Identity.Name);
                 var susers = entities.users.ToList();
    
                var pplquery = (from suser in susers.AsQueryable()
                                select new { userId = suser.IdUser, FirstName = suser.contactinfo.FirstName, LastName = suser.contactinfo.LastName, added = 
                                    u.user1.Any(cusr => cusr.IdUser == suser.IdUser)}).Take(15);
    
    
            }
