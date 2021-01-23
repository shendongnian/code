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
          return (from u in db.Users
                 let isActive = (u.StartDate < DateTime.Now || u.StartDate == null) && (u.EndDate > DateTime.Now || u.EndDate == null);
                 where isActive
                 select new UserDTO()
                 {
                    StartDate = u.StartDate,
                    EndDate   = u.EndDate,
                    IsActive  = isActive                 
                 }).ToList();
      }
    }
