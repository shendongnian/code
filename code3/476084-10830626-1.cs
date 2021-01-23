    public class CreateRepository
     {   
    
       public List<User> GetAllUserNames()
           {
              return db.User.OrderBy(f => f.Username).ToList();
           }
     }
