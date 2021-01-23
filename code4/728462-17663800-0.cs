    private void button1_Click(object sender, EventArgs e)
            {
                if (Regex.IsMatch(textBox1.Text, @"(a|e)"))
                {
                    MessageBox.Show("your word contains a or e");
                }
            }
