    //Here we create a path for a new entry,
    //but this time with the '\' in the end, its a folder
    string sEntry = sFolder.Substring(iFolderOffset) + "\\";
    sEntry = ZipEntry.CleanName(sEntry);
    ZipEntry zeOutput = new ZipEntry(sEntry);
    zsOutput.PutNextEntry(zeOutput);
    zsOutput.CloseEntry();
