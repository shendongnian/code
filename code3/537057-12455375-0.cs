    discFormatData = new MsftDiscFormat2Data();
    discFormatData.Recorder = discRecorder;
    IMAPI_MEDIA_PHYSICAL_TYPE mediaType = discFormatData.CurrentPhysicalMediaType;
    fileSystemImage = new MsftFileSystemImage();
    fileSystemImage.ChooseImageDefaultsForMediaType(mediaType);
    if (!discFormatData.MediaHeuristicallyBlank)
    {
         fileSystemImage.MultisessionInterfaces = discFormatData.MultisessionInterfaces;
         fileSystemImage.ImportFileSystem();
    }
    Int64 freeMediaBlocks = fileSystemImage.FreeMediaBlocks;
