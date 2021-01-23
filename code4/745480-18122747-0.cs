    private void button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        using (FileStream fs = new FileStream(
            @"myFilePath.txt", FileMode.Open, FileAccess.Read))
            {
                int bufferSize = 50;
                byte[] c = null;
                while (fs.Length - fs.Position > 0)
                {
                    c = new byte[bufferSize];
                    fs.Read(c, 0, c.Length);
                    Invoke(new Action(() =>
                        richTextBox1.AppendText(
                            new string(UnicodeEncoding.ASCII.GetChars(c)))));
                }
            }
        }
