	string path = @"E:\AppServ\Example.txt";
	if (!File.Exists(path))
	{
		using (var txtFile = File.AppendText(path))
		{
			txtFile.WriteLine("The very first line!");
		}
	}
	else if (File.Exists(path))
	{     
		using (var txtFile = File.AppendText(path))
		{
			txtFile.WriteLine("The next line!");
		}
	}
