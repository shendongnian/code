            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timer2_Tick);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
                txt_trp.BackColor = Color.Red;
                txt_trm.BackColor = Color.Yellow;
                timer2.Enabled = true;
                timer1.Enabled = false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
                txt_trp.BackColor = Color.Yellow;
                txt_trm.BackColor = Color.Red;
                timer1.Enabled = true;
                timer2.Enabled = false;
        }
