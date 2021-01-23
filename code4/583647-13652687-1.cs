    string filePath = "test.txt";
    var existingLines = new HashSet<string>(File.ReadAllLines(filePath));
    
    var linesToWrite = new List<string>();
    foreach (string item in listBox2.Items)
    {
        if (existingLines.Add(item))
        {
            linesToWrite.Add(item);
        }
        else
        {
            //this is a duplicate!!!
        }
    }
    
    File.AppendAllLines(filePath, linesToWrite);
