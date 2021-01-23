        private void Form1_Load(object sender, EventArgs e)
        {
                comboBox1.Items.Add(1);
                comboBox1.Items.Add(2);
                comboBox1.Items.Add(3);
                comboBox2.Visible = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "3")
            {
                comboBox2.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;
            }
        }
