        foreach (System.IO.DirectoryInfo dirInfo in subDirs)
        {
            // Resursive call for each subdirectory.
            WalkDirectoryTree(dirInfo, System.IO.Path.Combine(DestinationFolder, dirInfo.Name));
        }
