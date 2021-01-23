    private void trayIcon_MouseDown (object sender,MouseEventArgs e)
    {
      //add you menu items to context menu
      contextMenu.Items.Add(item);
      contextMenu.IsOpen = true;  
    }
 
