    Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog dlg = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
    dlg.Title = "Pick Folder";
    dlg.IsFolderPicker = true;
    dlg.InitialDirectory = Environment.SpecialFolder.Personal.ToString();  // If default setting does not exist, pick the Personal folder
    dlg.AddToMostRecentlyUsedList = false;
    dlg.AllowNonFileSystemItems = true;
    dlg.DefaultDirectory = dlg.InitialDirectory;
    dlg.EnsurePathExists = true;
    dlg.EnsureFileExists = false;
    dlg.EnsureReadOnly = false;
    dlg.EnsureValidNames = true;
    dlg.Multiselect = true;
    dlg.ShowPlacesList = true;
    if (dlg.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
    {
        foreach ( string dirname in dlg.FileNames )
        {
            var libFolders = ExpandFolderPath(dirname);
            if ( libFolders == null )
            {
                MessageBox.Show("Could not add '" + dirname + "', please try another.");
            }
            else
            {
                foreach ( string libfolder in libFolders )
                {
                    DoWork(libfolder);
                }
            }
        }
    }
