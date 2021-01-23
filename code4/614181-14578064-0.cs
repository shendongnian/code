    slide.Copy();
    if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap))
    {
        ImageSource imgSource = BinaryStructConverter.ImageFromClipboardDib();
    }
