        using (SMEntities db = new SMEntities())
        {
            User user = db.Users.First(x => x.Username == username);
            return user.Roles.Select(r => r.Type).ToArray();
        }
