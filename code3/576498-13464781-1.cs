    class Program
    {
      static void Main(string[] args)
      {
        var users = new List<string> { "A", "B", "C", "D" };
        var roles = new List<string> { "User", "Admin", "Superuser"};
        //User A has roles: User, Admin, Superuser
        Debug.Assert(IsUserInRole(users[0], roles[0]) == true);
        Debug.Assert(IsUserInRole(users[0], roles[1]) == true);
        Debug.Assert(IsUserInRole(users[0], roles[2]) == true);
        //User B has roles: User, Admin
        Debug.Assert(IsUserInRole(users[1], roles[0]) == true);
        Debug.Assert(IsUserInRole(users[1], roles[1]) == true);
        Debug.Assert(IsUserInRole(users[1], roles[2]) == false);
        //User C has roles: User
        Debug.Assert(IsUserInRole(users[2], roles[0]) == true);
        Debug.Assert(IsUserInRole(users[2], roles[1]) == false);
        Debug.Assert(IsUserInRole(users[2], roles[2]) == false);
        
        //User D has no roles
        Debug.Assert(IsUserInRole(users[3], roles[0]) == false);
        Debug.Assert(IsUserInRole(users[3], roles[1]) == false);
        Debug.Assert(IsUserInRole(users[3], roles[2]) == false);
        Debugger.Break();
      }
      public static bool IsUserInRole(string username, string roleName)
      {
        using(var roleRepository = new RoleRepository())
        {
          return roleRepository.Roles.Any(r => r.RoleName == roleName && r.UserRoles.Any(ur => ur.User.UserName == username));
        }
      }
    }
    public interface IRoleRepository : IDisposable
    {
    }
    public class RoleRepository : IRoleRepository
    {
      private Context context = new Context();
      public IQueryable<Role> Roles
      {
        get
        {
          return this.context.Roles.AsQueryable<Role>();
        }
      }
    
      public void Dispose()
      {
 	      //Do nothing
      }
    }
    public class Context : IDisposable
    {
      public IList<User> Users { get; set; }
      public IList<Role> Roles { get; set; }
      public IList<UserRole> UserRoles { get; set; }
      public Context()
      {
        //Generate Some Fake Data
        Users = new List<User>();
        Users.Add(new User { UserID = 1, UserName = "A" });
        Users.Add(new User { UserID = 2, UserName = "B" });
        Users.Add(new User { UserID = 3, UserName = "C" });
        Users.Add(new User { UserID = 4, UserName = "D" });
        Roles = new List<Role>();
        Roles.Add(new Role { RoleID = 1, RoleName = "User" });
        Roles.Add(new Role { RoleID = 2, RoleName = "Admin" });
        Roles.Add(new Role { RoleID = 3, RoleName = "Superuser" });
        UserRoles = new List<UserRole>();
        UserRoles.Add(new UserRole(1, Users[0], Roles[0]));
        UserRoles.Add(new UserRole(1, Users[0], Roles[1]));
        UserRoles.Add(new UserRole(1, Users[0], Roles[2]));
        UserRoles.Add(new UserRole(1, Users[1], Roles[0]));
        UserRoles.Add(new UserRole(1, Users[1], Roles[1]));
        UserRoles.Add(new UserRole(1, Users[2], Roles[0]));
        //User A has roles: User, Admin, Superuser
        //User B has roles: User, Admin
        //User C has roles: User
        //User D has no roles
      }
      public void Dispose()
      {
        //Do nothing
      }
    }
  
    public class User
    {
      public int UserID { get; set; }
      public string UserName { get; set; }
      public IList<UserRole> UserRoles { get; set; }
      public User()
      {
        UserRoles = new List<UserRole>();
      }
    }
    public class Role
    {
      public int RoleID { get; set; }
      public string RoleName { get; set; }
      
      public IList<UserRole> UserRoles { get; set; }
      public Role()
      {
        UserRoles = new List<UserRole>();
      }
    }
    public class UserRole
    {
      public int UserRoleID { get; set; }
      public int UserId { get; set; }
      public User User { get; set; }
      public int RoleId { get; set; }
      public Role Role { get; set; }
      public UserRole(int id, User user, Role role)
      {
        UserRoleID = id;
        UserId = user.UserID;
        User = user;
        user.UserRoles.Add(this);
        RoleId = role.RoleID;
        Role = role;
        role.UserRoles.Add(this);
      }
    }
