     private void Form1_Load(object sender, EventArgs e)
            {
                 //label1 = your tick
                label1.Visible = false;
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                //if same, show, if different, hide
                if (string.Compare(textBox1.Text, textBox2.Text, true) == 0)
                    label1.Visible = true;
                else
                    label1.Visible = false;
            }
    
            private void textBox2_TextChanged(object sender, EventArgs e)
            {
                 //if same, show, if different, hide
                if (string.Compare(textBox1.Text, textBox2.Text, true) == 0)
                    label1.Visible = true;
                else
                    label1.Visible = false;
            }
