    private void FormB_Load(object sender, EventArgs e)
        {
            panel1.Location = panel2.Location = new Point();
            timer1.Start();
    
            if (!first)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel2.Dock = DockStyle.Fill;
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel1.Dock = DockStyle.Fill;
            }
        }
