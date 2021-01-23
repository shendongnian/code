    private void button1_Click(object sender, EventArgs e)
            {
                string line = null;
                using (StreamReader reader = new StreamReader(PathToYourFile))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                         richTextBox1.AppendText(string.Format("http://website.com/q='{0}'", line) + Environment.NewLine);
                    }
                }
            }
