    private void pinnedAppsListBox_MouseHover(object sender, EventArgs e){
       Point point = pinnedAppsListBox.PointToClient(Cursor.Position);
       int index = pinnedAppsListBox.IndexFromPoint(point);
       if (index < 0) return;
       //Do any action with the item
       pinnedAppsListBox.GetItemRectangle(index).Inflate(1,2);
    }
 
