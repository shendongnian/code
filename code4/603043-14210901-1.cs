    System.IO.StreamReader inputFile = new System.IO.StreamReader(sourceFilePath);
	while (inputFile.Peek() >= 0) {
		string lineData = inputFile.ReadLine();
		//Do something with lineData 
	}
	inputFile.Close();
	inputFile.Dispose();
