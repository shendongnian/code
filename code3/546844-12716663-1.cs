	try
	{
		while (reader.Read()) { }
	}
	catch (Exception)
	{
		Console.Out.WriteLine("We have excpetion, this is wrong file");
	}
	while (reader.Read()) { } // we have eof so we don't get exception only false 
