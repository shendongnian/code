			List<User> result = ims.ListUsers(req).ListUsersResult.Users;
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
			foreach (User user in result.Where(x => x.UserName.Contains('@')))
			{
				string sql = @"INSERT INTO UserInfo (UserName) VALUES (@UserName)";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@UserName", user.UserName);
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close();
				}
			}
