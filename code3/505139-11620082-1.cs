	private static int? GetUSERS(string hkval)
	{
		using (MySqlConnection conn = new MySqlConnection("..."))
		{
			conn.Open();
			MySqlCommand cmd = new MySqlCommand("Select USERS from HK where UPTIME=@hkval", conn);
			cmd.Parameters.AddWithValue("hkval", hkval);
			MySqlDataReader reader = cmd.ExecuteReader();
			if (reader.Read())
				return reader["USERS"] as int?;
			return null;
		}
	}
	public static void Main()
	{
		int hkday = (int)GetUSERS("HKDAY");
		int hkall = (int)GetUSERS("HKALL");
		Console.WriteLine(String.Format("{0:N0}\n{1:N0}\n", hkday, hkall));
	}
