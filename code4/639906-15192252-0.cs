    private void SaveTextboxes()
    {
        List<string> linesToSave = new List<string>();
        linesToSave.Add(textBox1.Lines.Length.ToString());
        linesToSave.AddRange(textBox1.Lines);
        linesToSave.Add(textBox2.Lines.Length.ToString());
        linesToSave.AddRange(textBox2.Lines);
        File.WriteAllLines(filename, linesToSave);
    }
    private void LoadTextboxes()
    {
        string[] loadedLines = File.ReadAllLines(filename);
        int index = 0;
        int n = int.Parse(loadedLines[index]);
        string[] lines = new string[n];
        Array.Copy(loadedLines, index + 1, lines, 0, n);
        textBox1.Lines = lines;
        index += n + 1;
        n = int.Parse(loadedLines[index]);
        lines = new string[n];
        Array.Copy(loadedLines, index + 1, lines, 0, n);
        textBox2.Lines = lines;
    }
