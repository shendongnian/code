        int total = 0;
        bool newNum = true;
        //1
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = newNum ? "1" : textBox1.Text + "1";
            newNum = false;
        }
        //Add
        private void button2_Click(object sender, EventArgs e)
        {
            newNum = true;
            total += int.Parse(textBox1.Text);
            textBox1.Clear();
        }
        //Equals
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = total.ToString();
        }
