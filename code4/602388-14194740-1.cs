    private void SetTextButton_Click(object sender, EventArgs e)
    {
        string longText = "Very Long Text";
        Thread t = new Thread(() => AssignLongText(longText));
        t.Start();
    }
    private void AssignLongText(longText)
    {
        Invoke(new Action(() => richTextBox1.AppendText(text)));
    }
