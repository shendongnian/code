	public class Administrator
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
	}
	public class User : EntityBase
	{
		public string UserName { get; set; }
		public string Email { get; set; }
	}
