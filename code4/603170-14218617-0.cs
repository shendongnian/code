    private void UpdateListView() {
       ImageList IconList = new ImageList();
       IconList.Images.Add(
            BlackFox.Win32.Icons.IconFromExtensionShell(".*",
            BlackFox.Win32.Icons.SystemIconSize.Small));
       YourListview.SmallImageList = IconList;
            
       //Add the items to your Listview                
    }
