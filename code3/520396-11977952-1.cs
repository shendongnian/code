    foreach (string s in filePaths) {
    //goes through each line in each file
    string[] lines = System.IO.File.ReadAllLines(s);
    for (int i=0;i < lines.Length; i++)
    {
        if (line[i].Contains("Exception:"))
        {
            // Handle line[i] as Exception, line[i+1] as Message, line[i+2] as Source
        }
        else if (line[i].Contains("["))
        {
            // Same as you had before
        }
    }
    // same as before
}
