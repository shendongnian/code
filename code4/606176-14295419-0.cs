        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string line = string.Format("{0},{1}"
                , textBox1.Text
                , textBox2.Text);
                File.AppendAllText(saveFileDialog1.FileName, line, Encoding.GetEncoding(1252));
            }
        }
