    foreach (RichTextBox c in tableLayoutPanel1.Controls)
    {
    if (!c.Text.IsNullOrWhiteSpace)
    {
    string[] lines = c.Text.Split('\n');
    string[] uniqueLines = GetUniqueLines(lines);//Some line-uniqueness checking algorithm
    c.Text = String.Join('\n',uniqueLines)
    }
    }
