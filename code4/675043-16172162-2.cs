    string[] lines = System.IO.File.ReadAllLines(YOUR INPUT FILE);
    StringBuilder builder = new StringBuilder();
    foreach (string line in lines)
    {
        var temp = line.Split('\t');
        builder.AppendLine(string.Join(";", temp[0], temp[1]));
        //builder.AppendLine(string.Format("{0}; {1}", temp[0], temp[1]));
    }
    System.IO.File.WriteAllText(YOUR OUTPUT FILE, builder.ToString());
