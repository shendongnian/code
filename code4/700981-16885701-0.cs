    public void TextFileToDictionary()
    {
        Dictionary<string, string> d = new Dictionary<string, string>();
    
        using (var sr = new StreamReader("txttodictionary.txt"))
        {
            string line = null;
    
            // while it reads a key
            while ((line = sr.ReadLine()) != null)
            {
                // add the key and whatever it 
                // can read next as the value
                d.Add(line, sr.ReadLine());
            }
        }
    }
