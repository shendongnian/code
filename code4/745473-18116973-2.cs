    private void button1_Click(object sender, EventArgs e)
    {
        foreach (var line in File.ReadLines(@"C:\Users\Dax\AppData\Local\Temp\dd_VSMsiLog0D85.txt", Encoding.ASCII))
        {
            richTextBox1.AppendText(line + "\r\n");
            Application.DoEvents();
        }
    }
