    private void button1_Click(object sender, EventArgs e)
    {
        TextRange range = new TextRange(richTextBox1.Document.ContentStart,richTextBox1.Document.ContentEnd);
        // You could also split by block or something, but I am keeping it simple
        string[] lines = range.Text.Split(Environment.NewLine.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
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
        // Everything is added back to one paragraph, you can alter to many paragraphs if you need to preserve
        FlowDocument doc = new FlowDocument();
        Paragraph p = new Paragraph();
        foreach (string line in formattedLines)
        {
            p.Inlines.Add(new Run(line));
            p.Inlines.Add(new LineBreak());
        }
        doc.Blocks.Add(p);
        richTextBox1.Document = doc;
    }
