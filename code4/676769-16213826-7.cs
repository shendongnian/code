    public void createEntry(String npcName)
    {
        //npcName = @"[/item1]"; <-- note the '/'.
        string lineToAdd = "//Add a line here in between the specific boundaries";
        string fileName = "test.txt";
        List<string> txtLines = new List<string>();
        //Fill a List<string> with the lines from the txt file.
        foreach (string str in File.ReadAllLines(fileName))
        {
            txtLines.Add(str);
        }
        //Insert the line you want to add last under the tag 'item1'.
        txtLines.Insert(txtLines.IndexOf(npcName), lineToAdd);
        //Clear the file. The using block will close the connection immediately.
        using (File.Create(fileName)) { }
        //Add the lines including the new one.
        foreach (string str in txtLines)
        {
            File.AppendAllText(fileName, str + Environment.NewLine);
        }
    }
