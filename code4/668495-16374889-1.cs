    private void TextBox_LeaveEvent(object sender, EventArgs e)
    {
    	var tb = sender as TextBox;
    	if(tb.Text.Length>0){
        	decimal cubic = Convert.ToDecimal(tb.Text);
        	tb.Text = string.Format("{0:c}", Convert.ToDecimal(cubic));
        	label1.Text = tb.Text;
    	}
    }
