        private void rB_OFF_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                MessageBox.Show("You clicked OFF");
            }            
        }
        private void rB_ON_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                MessageBox.Show("You clicked ON");
            }            
        }
