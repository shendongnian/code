    string fileToRead = "c:\\file.txt";
    public void EditValue(string oldValue, string newValue, Control Item)
    {
        if (Item is TextBox)
        {
           string text = File.ReadAllText(fileToRead);
           string[] words = text.Split(new char[] {' '}); // assuming space-delimited
           words[3] = "new value";   // replace the target value
           text = "";
           foreach (string w in words)
           {
               text += w + " ";   // build our new string
           }
           File.WriteAllText(activeSaveFile, text.Trim());   // and write it back out
        }
    }
