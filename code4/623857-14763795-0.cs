    var filteredUsers = _dbContext.Users
        .Where(user => user.MultiplyItems
            .Any(item => delegateList.Contains(item.Id)))
        .Select(user => new UserModel
            {
                //the UserModel initialization
            });
