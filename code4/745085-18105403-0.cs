    foreach(TabPage page in yourTabControl.TabPages){
       foreach(Control c in page.Controls){
          LoopThroughControls(c);
       }  
    }
    private void LoopThroughControls(Control parent){
       foreach(Control c in parent.Controls)
          LoopThroughControls(c);
    }
