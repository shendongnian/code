      ...
      // Need to remove all removable drivers first
      ToolStripMenuItem copyToItem = menu_PopUp.Items[3] as ToolStripMenuItem;
    
      // Assuming that "Desktop" menu item is the top one, 
      // we should delete all the items except #0 
      for (int i = copyToItem.DropDownItems.Count - 1; i >= 1; --i)
        copyToItem.DropDownItems.RemoveAt(i);
    
      ...
      // to update the USB drivers when opening new pop up menu
      DriveInfo[] ListDrives = DriveInfo.GetDrives();
    
      foreach (DriveInfo Drive in ListDrives) {
        if (Drive.DriveType == DriveType.Removable) {
          // add to popup menu, from: http://stackoverflow.com/questions/5868446/how-to-add-sub-menu-items-in-contextmenustrip-using-c4-0
          ToolStripItem item = (menu_PopUp.Items[3] as ToolStripMenuItem).DropDownItems.Add(Drive.Name + " (" + Drive.VolumeLabel + ")");
      
          item.Tag = Drive.Name; // <- bind (via tag) driver name with menu item
          item.Click += OnRemovableDriveClick;
        }
      }
    
    ...
    
      private void OnRemovableDriveClick(object sender, EventArgs e) {
        ToolStripItem item = sender as ToolStripItem;
    
        String driveName = item.Tag as String;
        ...
      
