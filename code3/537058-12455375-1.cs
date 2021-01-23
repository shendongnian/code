    discFormatData = new MsftDiscFormat2Data { Recorder = discRecorder };
    fileSystemImage = new MsftFileSystemImage();
    fileSystemImage.ChooseImageDefaults(discRecorder);
    if (!discFormatData.MediaHeuristicallyBlank)
    {
        fileSystemImage.MultisessionInterfaces = discFormatData.MultisessionInterfaces;
        fileSystemImage.ImportFileSystem();
    }
    Int64 freeMediaBlocks = fileSystemImage.FreeMediaBlocks;
