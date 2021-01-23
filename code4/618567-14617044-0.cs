        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.btn1 = button1.BackColor;
            Properties.Settings.Default.btn2 = button2.BackColor;
            Properties.Settings.Default.btn3 = button3.BackColor;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.BackColor = Properties.Settings.Default.btn1;
            button2.BackColor = Properties.Settings.Default.btn2;
            button3.BackColor = Properties.Settings.Default.btn3;
        }
