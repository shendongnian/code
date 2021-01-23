	Encoding GreekEncoding = Encoding.GetEncoding(1254);
	using (StreamReader sr = new StreamReader(sNotepadName+".txt", GreekEncoding))
	{
		while ((input = sr.ReadLine()) != null)
		{
			sTempInput = input.Split('='); //Data - double dotted above A=A
			lMyDictionary.Add(sTempInput[0],sTempInput[1]);
			
		}
	}
