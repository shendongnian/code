    public void UpdateUser(DomainUser user)
    {
    _dataTool.ExecuteInsertOrUpdate(Db, () =>
            {
                Db.User.First(u => u.UserId == user.Id).Email = user.Email;
                Db.User.First(u => u.UserId == user.Id).Name = user.Name;
                Db.User.First(u => u.UserId == user.Id).LastName = user.LastName;
                Db.User.First(u => u.UserId == user.Id).Password = user.Password;
                return null;
            });    
    }
