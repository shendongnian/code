        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                for (int i = 0; i < richTextBox1.TextLength; i++)
                {
                    richTextBox1.Find(textBox1.Text, i, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Red;
                }
            }
            else
            {
                for (int i = 0; i < richTextBox1.TextLength; i++)
                {
                    richTextBox1.SelectAll();
                    richTextBox1.SelectionBackColor = Color.White;
                }
            }
        }[lets make it!][1]
