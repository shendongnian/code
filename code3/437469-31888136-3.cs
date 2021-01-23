            var user = new User
            {
                Id = Request.Id,
                UserName = Request.UserName,
                FirstName = Request.FirstName
            };
            var expressions = new List<Expression<Func<User, object>>> 
                     { 
                         x => x.UserName, 
                         x => x.FirstName
                     };
            context.Entry(user).SetModified(expressions);
