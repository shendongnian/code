	private ObservableCollection<User> MyUsers { get; set; }
	private StudyEntities ssEntities;
	public MyMainWindow()
	{
		ssEntities = new StudyEntities();
		MyUsers = new ObservableCollection<User>(ssEntities.Users.ToList());
	}
	private void btnSave_Click(object sender, RoutedEventArgs e)
	{
		//Code for creating the User isntance MyUser
		MyUsers.Add(MyUser);
		ssEntities.Users.Add(MyUser);
		ssEntities.SaveChanges();
	}
