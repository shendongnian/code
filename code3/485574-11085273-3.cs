    string[] inputLines = textBox1.Text.Split('\n');
    if (inputLines.Length == 4)
    {
        string dayUsers = inputLines[2].Substring(inputLines[2].IndexOf(':') + 1).Trim();
        string allUsers = inputLines[3].Substring(inputLines[3].IndexOf(':') + 1).Trim();
    }
