    public void CreateEntry(string npcName) //npcName = "item1"
    {
        var fileName = "test.txt";
        var endTag = String.Format("[/{0}]", npcName);
        var lineToAdd = "//Add a line here in between the specific boundaries";
        //Fill a list with the lines from the txt file.
        var txtLines = File.ReadAllLines(fileName).ToList();
        //Insert the line you want to add last under the tag 'item1'.
        txtLines.Insert(txtLines.IndexOf(endTag), lineToAdd);
        //Add the lines including the new one.
        File.WriteAllLines(fileName, txtLines);
    }
