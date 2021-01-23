    private ObservableCollection<User> _myUsers;
		public ObservableCollection<User> MyUsers
		{
			get
			{
				if (_myUsers == null)
				{
					_myUsers = new ObservableCollection<User>();
				}
				return _myUsers;
			}
		}
