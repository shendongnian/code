    StreamWriter writer = null;
    using (writer = File.CreateText("output.txt"))
    {
        foreach (string line in File.ReadLines("input.txt"))
        {
            if (line.StartsWith("ID2")) {
                writer.WriteLine(line.Replace("Value2", "NewValue2"));
            }
            else {
                writer.WriteLine(line);
            }
        }
    }
                
    File.Replace("output.txt", "input.txt", "input.bak");
