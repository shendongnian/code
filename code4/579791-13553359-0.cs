    public IList<string> GetEditedContent(string fileName, string word, string replacement)
    {            
        List<string> list = new List<string>();
        using (StreamReader reader = new StreamReader(directory + fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {                    
                line = line.Replace(word, replacement);
                list.Add(line);
                Console.WriteLine(line);
            }
            reader.Close();
        }      
        return list;
    }
        // Example how write list to a file. 
     using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
        {
            foreach (string listItem in list)
            {
                file.WriteLine(line);
               
            }
        }
