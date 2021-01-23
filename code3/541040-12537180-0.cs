        private bool changed = false;
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!changed)
            {
                changed = true;
                ComboBox2.Text = "";
                changed = false;
            }
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!changed)
            {
                changed = true; 
                ComboBox1.Text = "";
                changed = false;
            }            
        } 
