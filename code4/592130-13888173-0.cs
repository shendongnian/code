    // To populate list box with csv files from given path
    private void PopulateListBox(ListBox lsb, string Folder, string FileType)
    {
        DirectoryInfo dinfo = new DirectoryInfo(Folder);
        FileInfo[] Files = dinfo.GetFiles(FileType);
        foreach (FileInfo file in Files)
        {
            lsb.Items.Add(file); //<-- note here
        }
    }
    
    String strItem;
    foreach (FileInfo selecteditem in ExcelListBox.SelectedItems)
    {
         StreamReader sr = new StreamReader(selecteditem.FullName);
         //or whatever
    }
