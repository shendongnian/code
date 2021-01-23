    private void BuildFolderTree(DirectoryInfo parentFolder, XElement parentElement)
    {
        // Find all the subfolders under this folder.
        foreach (DirectoryInfo folderInfo in parentFolder.GetDirectories())
        {
            // Add this folder to the doc.
            XElement folderElement = new XElement("Folder", new XAttribute("Name", folderInfo.Name), new XAttribute("Path", folderInfo.FullName));
                    parentElement.Add(folderElement);
            // Recurse into this folder.
            BuildFolderTree(folderInfo, folderElement);
        }
        // Process all the files in this folder
        foreach (FileInfo fileInfo in parentFolder.GetFiles("*.*"))
        {
            // Add this file minus its extension.
            parentElement.Add(new XElement(STR_File, new XAttribute("Name", fileInfo.Name), new XAttribute("Path", fileInfo.FullName)));
        }
    }
    // main code
    DriveInfo di = new DriveInfo("M");
    XElement usbKeyTreeElement = new XElement("USBKey");
    BuildFolderTree(di.RootDirectory, usbKeyTreeElement);
    string usbKeyString = usbKeyTreeElement.ToString();
