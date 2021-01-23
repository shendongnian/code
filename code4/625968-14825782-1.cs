     [Table("webpages_Roles")]
    public class RoleModel
    {
    	[Key]
    	public int RoleId { get; set; }
    	public string RoleName { get; set; }
    }
    
    [Table("webpages_UsersInRoles")]
    public class UsersInRole
    {
    	[Key, Column(Order=0)]
    	public int UserId { get; set; }
    	public virtual UserProfile User { get; set; }
    
    	[Key, Column(Order = 1)]
    	public int RoleId { get; set; }
    	public RoleModel Role { get; set; }
    }
