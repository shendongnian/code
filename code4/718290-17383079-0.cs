    private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
    {
        if (numericUpDown1.Value >= 10){
    	   numericUpDown1.Value = 0;
    	   MessageBox.Show("number must be less than 10!");
        }
    }
    
    private void numericUpDown1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right) {
    	   if (numericUpDown1.Value >= 10){
    	       numericUpDown1.Value = 0;
    	       MessageBox.Show("number must be less than 10!");
    	   }
        }
    }
