    private IEnumerable<User> GetUser(int cant, Func<User, bool> filter)
    {
        return (from dcu in _db.All<User>().Where(a => filter(a))
                join c in _db.All<Client>() on dcu.IdClient equals c.IdClient into temp
                from cli in temp.DefaultIfEmpty()
                select new {Usuer = dcu, Client = cli}).
            Take(cant).Select(uc => _usersMapper.Map(uc.User, uc.Client)).AsEnumerable();
    }
