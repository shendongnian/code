    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (lastFocused == textBox1)
                {
                    textBox1.Text = listBox1.SelectedItem.ToString();
                }
                else if (lastFocused == textBox2)
                {
                    textBox2.Text = listBox1.SelectedItem.ToString();
                }
                ......
            }
