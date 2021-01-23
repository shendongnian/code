    public class UserDTO
    {
       public bool IsActive{get;set;}
       public DateTime? StartDate{get;set;}
       public DateTime? EndDate{get;set;}
    } 
    
    public IList<UserDTO> GetActiveUsers()
    {
      using(var db = new DbContext())
      {
          var users = GetUsers(db);
          return users.Where(u => u.IsActive).ToList();
      }
    }
    private IQuerable<UserDTO> GetUsers(DbContext db)
    { 
        return (from u in db.Users
                select new UserDTO()
                {
                   StartDate = u.StartDate,
                   EndDate   = u.EndDate,
                   IsActive  = (u.StartDate < DateTime.Now || u.StartDate == null) && (u.EndDate > DateTime.Now || u.EndDate == null)
                });
    }
