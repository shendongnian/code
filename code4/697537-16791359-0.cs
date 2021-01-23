    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
           
       if(CheckBox.Checked)
       {
           RequiredFieldValidator1.Enabled = true;
           RequiredFieldValidator1.ValidationGroup = "anything";
           Button1.ValidationGroup = "anything";// your save button
    
       }
       else
       {
           RequiredFieldValidator1.Enabled = false;
           RequiredFieldValidator1.ValidationGroup = string.Empty;
           Button1.ValidationGroup = string.Empty; // save button
       }
    }
