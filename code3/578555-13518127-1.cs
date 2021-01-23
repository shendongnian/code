    public class User
    {
         public int Id { get; set; }
         public ICollection<Permission> Permissions { get; set; }
    }
    public class Permission
    {
       public int Id { get; set; }
       public int Value { get; set; }
    }
