    public partial class Role
    {
       public virtual int Id {get;set;}
       public virtual string RoleName {get;set;}
       public virtual ICollection<User> Users { get; set; } // Here
    }
