		string path = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile) + "\\something\\myfile.txt";
		string previousNumber = System.IO.File.ReadAllText(path);
		int newNumber;
		if (int.TryParse(previousNumber, out newNumber))
		{
			newNumber++;
			using (FileStream fs = File.Create(path, 1024))
			{
				Byte[] info = new UTF8Encoding(true).GetBytes(newNumber.ToString());
				fs.Write(info, 0, info.Length);
			}
		}
