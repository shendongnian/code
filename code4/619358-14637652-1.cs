    public void AddTextToFile(string filePath, int lineNumber, string txt) //zero based lineNumber
    {
            Collection<string> newLines = new Collection<string>(File.ReadAllLines(filePath).ToList());
            if (lineNumber < newLines.Count)
                newLines.Insert(lineNumber, txt);
            else 
                newLines.Add(txt);
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (string s in newLines)
                    writer.WriteLine(s);
            }
    }
