	public class Menu
	{
		public int MenuId { get; set; }
		public bool IsActive { get; set; }
		public virtual ICollection<MenuMember> MenuMembers { get; set; }
	}
