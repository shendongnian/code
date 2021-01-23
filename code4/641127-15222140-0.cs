    ListViewItem itemProcess = new ListViewItem(theprocess.ProcessName);
    itemProcess.SubItems.Add(theprocess.Id.ToString());
    lvAppProg.Items.AddRange(new ListViewItem[] {itemProcess});
    itemProcess.ImageList = imageListSmall;
    itemProcess.ImageIndex = YOURIMAGEINDEX
