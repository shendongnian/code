        string fpath = "";
        // Iterate over each folder and find the one we want
        foreach ( var folder in allSpecialFolders )
        {
            if ( folder.ParsingName == foldername )
            {
                // We now have access to the xml path
                fpath = folder.Path;
            }
        }
        if ( fpath == "" )
            return null;
        var intFolders = GetLibraryInternalFolders(fpath);
        return intFolders.Folders.ToList();
