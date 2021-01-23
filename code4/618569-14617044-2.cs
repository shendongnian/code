        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.btn1 = button1.UseVisualStyleBackColor ? Color.Transparent : button1.BackColor;
            Properties.Settings.Default.btn2 = button1.UseVisualStyleBackColor ? Color.Transparent : button2.BackColor;
            Properties.Settings.Default.btn3 = button1.UseVisualStyleBackColor ? Color.Transparent : button3.BackColor;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.btn1 != Color.Transparent) button1.BackColor = Properties.Settings.Default.btn1;
            if (Properties.Settings.Default.btn2 != Color.Transparent) button1.BackColor = Properties.Settings.Default.btn2;
            if (Properties.Settings.Default.btn3 != Color.Transparent) button1.BackColor = Properties.Settings.Default.btn3;
        }
