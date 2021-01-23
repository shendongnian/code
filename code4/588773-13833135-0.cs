        int ct = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "\n\r";
            richTextBox1.Text += ct.ToString()+". "+textBox1.Text;
            richTextBox1.Text += ", " + textBox2.Text;
            form2.richTextBox1.Text += textBox2.Text + "\n";
            ct = ct + 1;
            using (StringReader reader = new StringReader(form2.richTextBox1.Text))
            {
                for (int i = 0; i < ct; i++)
                {
                    string A = reader.ReadLine();
                    richTextBox1.Find(A, RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
                }
            }
        }
