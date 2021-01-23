    string[] stopWord = new string[] { "is", "are", "am","could","will" };
    TextWriter writer = new StreamWriter("C:\\output.txt");
    StreamReader reader = new StreamReader("C:\\input.txt");
	
	string line;
    while ((line = reader.ReadLine()) != null)
    {
        foreach (string word in stopWord)
        {
            line = line.Replace(word, "");
        }
        writer.WriteLine(line);
    }
    reader.Close();
    writer.Close();
