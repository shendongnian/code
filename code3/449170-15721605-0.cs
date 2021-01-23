    using (FileStream stream = new FileStream(@"C:\tEMP\image_$i.tiff", FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        BitmapDecoder dec = BitmapDecoder.Create(stream, BitmapCreateOptions.IgnoreImageCache, BitmapCacheOption.None);
        BitmapEncoder enc = BitmapEncoder.Create(dec.CodecInfo.ContainerFormat);
        enc.Frames.Add(dec.Frames[frameIndex]);
    }
