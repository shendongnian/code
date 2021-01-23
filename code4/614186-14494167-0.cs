    StringBuilder newFile = new StringBuilder();
    string temp = "";
    string[] file = File.ReadAllLines(@"txtfile");
    
    foreach (string line in file)
    {
        if (line.Contains("string you want to replace"))
        {
            temp = line.Replace("string you want to replace", "New String");
            newFile.Append(temp + "\r\n");
            continue;
        }
        newFile.Append(line + "\r\n");
    }
    
    File.WriteAllText(@"txtfile", newFile.ToString());
