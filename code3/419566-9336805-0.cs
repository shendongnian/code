            List<User> users = new List<User>() 
            { 
                new User { Email = "a" }, 
                new User { Email = "b" } 
            };
            _repo.Setup(a => a.Single(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns<Expression<Func<User, bool>>>(predicate => users.AsQueryable()
                    .Where(predicate).SingleOrDefault());
