        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            using (new TriggerLock())
            {
                checkBox2.Checked = checkBox1.Checked;
                checkBox3.Checked = checkBox1.Checked;
            }
        }
    
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (TriggerLock.IsOpened)
            {
                MessageBox.Show("Changed in 2");
            }
        }
    
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (TriggerLock.IsOpened)
            {
                MessageBox.Show("Changed in 3");
            }
        }
