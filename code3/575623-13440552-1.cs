	public class AddUserTemplate
	{
		public Group Group { get; set; }
		public IList<User> Users { get; set; }
		public int SelectedUserId { get; set; }
		public User SelectedUser
		{
			get { return Users.Single(u => u.Id == SelectedUserId); }
		}
	}
