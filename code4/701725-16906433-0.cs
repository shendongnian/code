    internal class User
	{
		public User()
		{
			Roles = new List<UserRole>();
		}
		[Key]
		public int UserId { get; set; }
		public ICollection<UserRole> Roles { get; set; }
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
		public Role RoleInfo { get; set; }
	}
	internal class Role
	{
		[Key]
		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public int UserRoleId { get; set; }
		[ForeignKey("UserRoleId")]
		public UserRole UserRole { get; set; }
	}
