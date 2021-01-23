        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            string outputStr = textBox2.Text;
            if (!File.Exists(filePath))
            {
                MessageBox.Show(string.Format("Could not file file {0}", filePath));
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(outputStr);
                    writer.Flush();
                }
            }
        }
