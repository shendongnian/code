    Public static void GetFilesLocal( string path)
    {
        foreach (string f in Directory.GetFiles( path))
        {
            // Add to subFolderList.
        }
        foreach (string d in Directory.GetDirectories( path))
        {
            GetFilesLocal( d ); 
        }
    }
