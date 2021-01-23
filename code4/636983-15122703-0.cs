    int lineNumber = Form1.ab;
    // split the contents of the text box
    string text = textBox1.Text;
    string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    if (lineNumber < 0 || lineNumber > lines.Length)
    {
        MessageBox.Show("The line number is does not exist");
        return;
    }
    // get the character pos
    int selStart = 0;
    for (int i = 0; i < (lineNumber - 1); i++)
    {
        selStart += lines[i].Length + Environment.NewLine.Length;
    }
    textBox1.Focus();
    textBox1.SelectionStart = selStart;
    textBox1.SelectionLength = lines[lineNumber - 1].Length;
