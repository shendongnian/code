    private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (string s in listBox1.Items)
            {
                i++;
                if (i == 1)
                {
                    textBox1.Text = s;
                }
                if (i == 2)
                {
                    textBox2.Text = s;
                }
                if (i == 3)
                {
                    textBox3.Text = s;
                }
            }
        }
