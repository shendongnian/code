    StringBuilder newFile = new StringBuilder();
    string temp = "";
    string[] file = File.ReadAllLines(@"<File Path>");
    foreach (string line in file)
    {
        if (line.Contains("Security1"))
        {
        temp = line.Replace("Security1", "Security2");
        newFile.Append(temp + "\r\n");
        continue;
        }
    newFile.Append(line + "\r\n");
    }
    File.WriteAllText(@"<File Path>", newFile.ToString());
