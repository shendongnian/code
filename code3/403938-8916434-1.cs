    protected void MyCBox_CheckedChanged(object sender, EventArgs e)
    {
        if( ((CheckBox)sender).ToolTip == "cat1"
          { 
           Btn1.Enabled = true;
           Btn2.Enabled = false;
          }
        else 
          { 
           Btn1.Enabled = false;
           Btn2.Enabled = true;
          }          
           
    }
