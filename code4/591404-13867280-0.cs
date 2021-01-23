    string[] lines = System.IO.File.ReadAllLines("filename.txt");
    for (int i = 0; i < lines.Length; i++)
    {
        string line = lines[i];
        if (line == "what you are looking for")
           lines[i] = "";
    }
    string[] newLines = lines.Where(str => !string.IsNullOrEmpty(str)).ToArray();
    using (Stream stream = File.OpenWrite("filename.txt"))
    {
        using (StreamWriter sw = new StreamWriter(stream))
        {
            foreach (string line in newLines)
            {
                sw.WriteLine(line);  
            }
        }
    }
