	SqlDataReader reader = command.ExecuteReader();
	while (reader.Read())
	{
		int firstcell = reader.GetInt32(0);    // I assume your first column is int.
		string secondcell = reader.GetString(1);  // I assume your second column is string.
		string thirdcell = reader.GetString(2); // I assume your third column is string.
		Console.WriteLine("FirstCell = {0}, SecondCell = {1}, ThirdCell = {2}", firstcell, secondcell , thirdcell);
	}
