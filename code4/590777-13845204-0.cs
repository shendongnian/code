    private void button1_Click(object sender, EventArgs e)
    {
        string[] lines = richTextBox1.Lines;
        string[] formattedLines = new string[lines.Length];
        for (int l = 0; l < lines.Length; l++)
        {
            string line = lines[l];
            for (int i = 60; i < line.Length; i += 60)
            {
                int spaceIdx = line.LastIndexOf(" ", i);
                line = line.Remove(spaceIdx, 1); // Remove the space
                line = line.Insert(spaceIdx, Environment.NewLine);
            }
            formattedLines[l] = line;
        }
        richTextBox1.Lines = formattedLines;
    }
