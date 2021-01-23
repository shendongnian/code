    public class AdminRepository : IAdminRepository {
      public IQueryable<User> AllUsers {
        get { throw new NotImplementedException(); }
      }
      public IQueryable<Role> AllRoles {
        get { throw new NotImplementedException(); }
      }
      IQueryable<User> IRepository<User>.All {
        get { return AllUsers; }
      }
      IQueryable<Role> IRepository<Role>.All {
        get { return AllRoles; }
      }
      ...
    }
