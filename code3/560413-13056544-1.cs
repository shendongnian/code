    for (int i = 0; i < imageCount; ++i)
    {
        // The image info.
        var imageInfo = new IMAGEINFO();
    
        // Get the call to ImageList_GetImageInfo.
        if (!ImageList_GetImageInfo(imageList, i, ref imageInfo)
            throw new System.ComponentModel.Win32Exception();
