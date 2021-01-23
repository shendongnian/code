        private void FormB_Load(object sender, EventArgs e)
        {
            panel1.Location = panel2.Location = new Point();
            timer1.Start();
    
            if (!first)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                this.Size = new Size(panel2.Size.Width + 16, panel2.Size.Height + 38);
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
                this.Size = new Size(panel1.Size.Width + 16, panel1.Size.Height + 38);
            }
        }
