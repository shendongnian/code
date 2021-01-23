    private void button1_Click(object sender, EventArgs e)
    {
        var text = File.ReadAllText(@"C:\Users\Dax\AppData\Local\Temp\dd_VSMsiLog0D85.txt", Encoding.ASCII);
        const int chunkSize = 1000000;
        for (var i = 0; i < text.Length / chunkSize; ++i)
        {
            richTextBox1.AppendText(text.Substring(chunkSize * i, chunkSize));
            Application.DoEvents();
        }
    }
