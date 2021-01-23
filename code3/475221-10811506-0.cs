    private bool isfill = false;
    
            private void pictureBox1_Click(object sender, EventArgs e)
            {
                if (!isfill)
                {
                    pictureBox1.Dock = DockStyle.Fill;
                    pictureBox2.Visible = false;
                    isfill = true;
                }
                else
                {
                    pictureBox1.Dock = DockStyle.None;
                    pictureBox2.Visible = true;
                    isfill = false;
                }
            }
    
            private void pictureBox2_Click(object sender, EventArgs e)
            {
                if (!isfill)
                {
                    pictureBox2.Dock = DockStyle.Fill;
                    isfill = true;
                    pictureBox1.Visible = false;
                }
                else
                {
                    pictureBox2.Dock = DockStyle.None;
                    isfill = false;
                    pictureBox1.Visible = true;
                }
