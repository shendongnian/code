    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      const int WM_KEYDOWN = 0x100; 
      if (keyData == (Keys.Control | Keys.S)) {
        if (msg.Msg == WM_KEYDOWN)
          MySaveDataToDatabase(); // <- Do your save command
    
        return true; // <- Stop processing the WM_KeyDown message for Ctrl + S (and shortcut as well)
      }
    
      // All other key messages process as usual
      return base.ProcessCmdKey(ref msg, keyData);
    }
