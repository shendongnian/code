    public void updateCredits(string username)
     {
         myDBEntities Entity = new myDBEntities();
         User u = Entity.Users.SingleOrDefault(u => u.username == username)
         u.firstname = "name";
         u.credits = 11.5;
         Entity.Entry(u).State = EntityState.Modified;  //<-- manually indicate the entity was changed
         Entity.SaveChanges();
     }
