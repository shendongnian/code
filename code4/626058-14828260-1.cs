        private void Form1_Activated(object sender, EventArgs e)
        {
            Timer.Enabled = false;
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Timer.Enabled = true;
        }
