        public string[] RtbFullText;
        private void button7_Click(object sender, EventArgs e)
        {
            RtbFullText = richTextBox1.Text.Split('\n');
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //Filter
            richTextBox1.Text = "";
            foreach (string _s in RtbFullText)
            {
                if (_s.Contains("Filter"))
                    richTextBox1.Text += _s + "\n";
            }
        }
