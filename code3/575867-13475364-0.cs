        private void button1_Click(object sender, EventArgs e)
        {
            addLog("Button 1 clicked");
            button1.Enabled = false;
            button2.Enabled = false;
            panel1.Visible = false;
            panel2.Visible = true;
            button2.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            addLog("Button 2 clicked");
            button2.Enabled = false;
            panel2.Visible = false;
            panel1.Visible = true;
            button1.Enabled = true;
        }
