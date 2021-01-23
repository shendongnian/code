    var filteredUsers = delegateList == null 
        ? _dbContext.Users
        : _dbContext.Users.Where(user => user.MultiplyItems
            .Any(item => delegateList.Contains(item.Id)));
    var result = filteredUsers.Select(user => new UserModel
            {
                //the UserModel initialization
            });
