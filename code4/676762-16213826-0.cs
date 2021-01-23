    string npcName = @"[/item1]";
    string lineToAdd = "//Add a line here in between the specific boundaries";
    string fileName = "test.txt";
    List<string> txtLines = new List<string>();
    foreach (string str in File.ReadAllLines(fileName))
    {
        txtLines.Add(str);
    }
    txtLines.Insert(txtLines.IndexOf(npcName), lineToAdd);
    using (File.Create(fileName)) { }
    foreach (string str in txtLines)
    {
        File.AppendAllText(fileName, str + Environment.NewLine);
    }
