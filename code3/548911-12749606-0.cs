    string[] filea = File.ReadAllLines("test.txt");
    foreach (var s in filea)
    {
        string[] parts = s.Split(':');
        if (parts.Length == 2)
        {
            if (parts[0].Contains("Email"))
                richTextBox1.AppendText(parts[1].Trim());
            if (parts[0].Contains("Status"))
                richTextBox1.AppendText(":" + parts[1].Trim() + Environment.NewLine);
        }
    }
