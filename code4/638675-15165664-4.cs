    private void Form1_Load(object sender, EventArgs e)
    {
        LoadFile();
    }
    private void LoadFile()
    {
        if (!File.Exists(fileName))
        {
            WriteAllLines();
            return;
        }
        string[] lines = File.ReadAllLines(fileName);
        if (lines.Length != textBoxes.Length)
        {
            // the number of lines in the file doesn't fit so create a new file
            WriteAllLines();
            return;
        }
        for (int i = 0; i < lines.Length; i++)
        {
            textBoxes[i].Text = lines[i];
        }
    }
    private void WriteAllLines()
    {
        // this will create the file or overwrite an existing one
        File.WriteAllLines(fileName, textBoxes.Select(tb => tb.Text));
    }
