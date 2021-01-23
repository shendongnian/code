     private void button1_Click(object sender, EventArgs e)
            {
                Regex reg = new Regex("text",RegexOptions.IgnoreCase);
                foreach (Match find in reg.Matches(richTextBox1.Text))
                {
                    richTextBox1.Select(find.Index, find.Length);
                    richTextBox1.SelectionColor = Color.Red;
                }
            }
