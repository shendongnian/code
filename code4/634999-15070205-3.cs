    private void button1_Click(object sender, EventArgs e)
    {
        string line = null;
        OpenFileDialog loadfile = new OpenFileDialog();
        loadfile.Filter = ".txt (files txt)|*.txt";
        if (loadfile.ShowDialog() == DialogResult.OK)
        {
            using (StreamReader reader = new StreamReader(loadfile.FileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    richTextBox1.AppendText(Uri.EscapeUriString(string.Format("http://website.com/q='{0}'", line)) + Environment.NewLine);
                }
            }
        }
    }
