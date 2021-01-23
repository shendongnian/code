    internal class User
	{
		public User()
		{
			UserRoles = new List<UserRole>();
		}
		[Key]
		public int UserId { get; set; }
		public ICollection<UserRole> UserRoles { get; set; }
	}
	internal class UserRole
	{
		[Key]
		public int UserRoleId { get; set; }
		public int UserId { get; set; }
		public int RoleId { get; set; }
		[ForeignKey("UserId")]
		public User User { get; set; }
		[ForeignKey("RoleId")]
		public Role Role { get; set; }
	}
	internal class Role
	{
		public Role()
		{
			UserRoles = new List<UserRole>();
		}
		[Key]
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		
		public ICollection<UserRole> UserRoles { get; set; }
	}
