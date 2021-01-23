    public static string GetAllTextFromFile(FileStream theFile)
    {
            string fileText = "";
            using (StreamReader stream = new StreamReader(theFile))
            {
                string currentLine = "";
                while ((currentLine = stream.ReadLine()) != null)
                {
                    fileText += currentLine + "\n";
                }
            }
        
        return fileText;
    }
