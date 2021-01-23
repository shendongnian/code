        Form2 m;
        private void button1_Click(object sender, EventArgs e)
        {
            m = new Form2();
            m.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (m != null)
            {
                m.Close();
            }        
        }
