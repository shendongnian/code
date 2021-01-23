    public string FillRichText(string aPath)
    {
        string content = File.ReadAllText(aPath);
        richTextBox1.Text = content;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        FillRichText(@"help.txt");
    }
