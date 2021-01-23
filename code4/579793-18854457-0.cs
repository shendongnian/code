    public void EditorialResponse(string fileName, string word, string replacement, string saveFileName)
    {
        StreamReader reader = new StreamReader(directory + fileName);
        string input = reader.ReadToEnd();
    
        using (StreamWriter writer = new StreamWriter(directory + saveFileName, true))
        {
            {
                string output = input.Replace(word, replacement);
                writer.Write(output);                     
            }
            writer.Close();
        }
    }
