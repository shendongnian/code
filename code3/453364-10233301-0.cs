    string[] lines = File.ReadAllLines(@"C:\********\temperature.txt"); 
    StringBuilder temperatures = new StringBuilder();
    foreach (string line in lines)
    {
        string[] parts = line.Split('=');
        if (lines.Length > 1)
        {
            tempatures.Append(lines[1]));
            tempatures.Append("\n");
        }
    }
    File.WriteAllText(@"C:\*******\temperature2.txt", tempatures.ToString());
