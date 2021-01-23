    // The list of swear words
    List<string> swearWords = new List<string>();
    private void GetSwearWords()
    {
        // Get the path to the file that has the swear words list
        string path = <File Path>;
    
        // Open the text file
        TextReader reader = new StreamReader(path);
        
        // Loop through each line in the file.
        string line = "";
        while ((line = reader.ReadLine()) != null)
        {
           // Lower cases word and removes whitespaces
           string word = line.Trim().ToLower();
    
           // Adds the word to the list
           swearWords.Add(word);
        }
    }
