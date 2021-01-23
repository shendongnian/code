    private void RedTextBox_TextChanged(object sender, EventArgs e)
    {  
         RedBar.Value += 1; 
         if (RedBar.Value == RedBar.Maximum){ RedBar.Value = RedBar.Minimum; }
    } 
   
