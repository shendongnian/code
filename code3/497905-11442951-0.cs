    public bool UpdateUser(User userToUpdate)
    {
        using (DBContext _context = new DBContext())
        {
            try
            {
                User outUser = usersModel.Users.Single(x => x.UserId == userToUpdate.UserId);
                outUser = userToUpdate;
                _context.ApplyCurrentValues("Users", outUser);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // LOGS etc.
                return false;
            }
        }
    }
