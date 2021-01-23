    string[] filePaths = Directory.GetFiles(@"C:\test\", "*.config", SearchOption.AllDirectories);
    
    int counter = 0;
    string currentFile = string.Empty;
    string currentLine = string.Empty;
    string updatedLine = string.Empty;
    
    foreach (string file in filePaths)
    {
        currentFile = File.ReadAllText(file);
    
        if (currentFile.Contains("MySettings.xru"))
        {
            counter++;
            Debug.Print("Found in " + file);
    
            using (StreamReader streamReader = new StreamReader(file))
            {
                while (!streamReader.EndOfStream)
                {
                    currentLine = streamReader.ReadLine();
    
                    if (currentLine.Contains("MySettings.xru"))
                    {
                        updatedLine = currentLine.Replace("db001", "db002");
    
                        break;
                    }
                }
            }
    
            currentFile = currentFile.Replace(currentLine, updatedLine);
    
            // If file is ReadOnly then remove that attribute.
            FileAttributes attributes = File.GetAttributes(file);
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes(file, attributes ^ FileAttributes.ReadOnly);
    
            using (StreamWriter streamWriter = new StreamWriter(file))
            {
                streamWriter.Write(currentFile);
            }
        }
    }
