    string text = richTextBox1.Text;
    richTextBox1.Text = "";
    string[] splitted = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string line in splitted)
    {
        richTextBox1.AppendText(Environment.NewLine + line.Trim() + ";" + Environment.NewLine);
    }
