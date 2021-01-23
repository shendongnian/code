    private const int MaxCharsPerRow = 10;
    private const int MaxLines = 2;
    private void textBox1_TextChanged(object sender, EventArgs e) {
        string[] lines = textBox1.Lines;
        var newLines = new List<string>();
        for (int i = 0; i < lines.Length && i < MaxLines; i++) {
            newLines.Add(lines[i].Substring(0, Math.Min(lines[i].Length, MaxCharsPerRow)));
        }
        textBox1.Lines = newLines.ToArray();
    }
