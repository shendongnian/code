	public static void Main()
	{
		int? hkday = 0;
		int? hkall = 0;
		using (MySqlConnection conn = new MySqlConnection("..."))
		{
			conn.Open();
			MySqlCommand cmd = new MySqlCommand("Select USERS, UPTIME from HK where UPTIME IN ('HKDAY', 'HKALL')", conn);
	
			MySqlDataReader reader = cmd.ExecuteReader();
			//this assumes that there is only one record per 'HKDAY' and 'HKALL',
			//otherwise the last value will be stored
			while (reader.Read())
			{
				switch (reader["UPTIME"] as string)
				{
					case "HKDAY":
						hkday = reader["USERS"] as int?;
						break;
					case "HKALL":
						hkall = reader["USERS"] as int?;
						break;
				}
			}
		}
			
		Console.WriteLine(String.Format("{0:N0}\n{1:N0}\n", hkday, hkall));
	}
