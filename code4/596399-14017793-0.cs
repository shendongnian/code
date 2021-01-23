    private void button1_Click(object sender, EventArgs e)
    {
        bg.RunWorkerAsync(richTextBox1.Lines);
    }
    void bg_DoWork(object sender, DoWorkEventArgs e)
    {
        string[] lines = (string[])e.Argument;
        foreach(string vr in lines)
        {
        }
    }
