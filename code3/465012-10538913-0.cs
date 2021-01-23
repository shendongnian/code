    private void chkBox_CheckedChanged(object sender, System.EventArgs e) {
      if (sender is CheckBox) { 
        CheckBox checkbox = sender as CheckBox;
        //do you checkbox accounting here
        if (checkbox.Checked){
          //blah
        }else{
          //blah
        }
      }
    }
    
    // elsewhere..assign event handler
    chkBox.CheckedChanged += new EventHandler(chkBox_CheckedChanged);
