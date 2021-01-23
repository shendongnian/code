    int i;
    private void button1_Click(object sender, EventArgs e)
            {
                i = 1;
                label3.Text = "Principle";
                label4.Text = "Rate";
                label5.Text = "Time";
                label6.Text = "Simple Interest";
            }
 
    private void button2_Click(object sender, EventArgs e)
            {
                i = 2;
                label3.Text = "SI";
                label4.Text = "Rate";
                label5.Text = "Time";
                label6.Text = "Principle";
            }
    private void button5_Click(object sender, EventArgs e)
            {
                
                try
                {
                    if (i == 1)
                    {
                        si = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text)) / 100;
                        textBox4.Text = Convert.ToString(si);
                    }
                    if (i == 2)
                    {
                        p = (Convert.ToInt32(textBox1.Text) * 100) / (Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text));
                        textBox4.Text = Convert.ToString(p);
                    }
