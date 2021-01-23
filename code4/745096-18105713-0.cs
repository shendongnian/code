    Dictionary<string, string> resourceDictionary = new Dictionary<string, string>();
    private void fillDictionary(string path)
    {
        using (ResXResourceReader rxrr = new ResXResourceReader(path))
        {
            foreach (DictionaryEntry entry in rxrr)
            {
                //Fill the fillDictionary
            }
        }
    }
