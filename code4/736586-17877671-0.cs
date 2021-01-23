    private void comboBox_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
    {
    	if (e.KeyCode == Keys.Delete)
    	{
            	(sender as ComboBox).SelectedIndex = -1;    
    	}
    }
