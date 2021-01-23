    private void ReadTextFile()
    {
	string line;
	using (StreamReader reader = new StreamReader("file.txt"))
	{
	    line = reader.ReadLine();
	}
	Console.WriteLine(line);
    }
