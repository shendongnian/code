	class Myclass
	{
		static List<string> user_Name = new List<string>{ "admin", "user1", "user2" };
		static List<string> user_Password = new List<string>{ "admin", "123", "789" };
		public static void Check_Method(string u_name, string u_password)
		{
			for (int i = 0; i < user_Name.Length; i++)
			{
				if (u_name == user_Name[i] && u_password == user_Password[i])
				{
					MessageBox.Show("login successful");
					break;
				}
				else
				{
					if (i == (user_Name.Length - 1))
						MessageBox.Show("Badshow");
				}
			}
		}
		public static void add_user(string name, string password)
		{
			user_Name.Add(name);
			user_Password.Add(password);
		}
	}
