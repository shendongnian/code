    private void Initialize(Shell shell)
    {
        Folder mediaFolder = null;
        FolderItem media = null;
        try
        {
            mediaFolder = shell.NameSpace(Path.GetDirectoryName(path));
            media = mediaFolder.ParseName(Path.GetFileName(path));
    
            ...
        }
        finally
        {
            if (media != null)
                Marshal.ReleaseComObject(media);
            if (mediaFolder != null)
                Marshal.ReleaseComObject(mediaFolder);
        }
    }
