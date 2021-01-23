    // 3rd Party ActiveX control for tiff image files
    TIFFLib.TIFF tiff = new TIFFLib.TIFF();
    
    // Variant object that will hold image
    object blobVariant = new object();
    
    unsafe
    {
        fixed (byte* p = imageBlobBytes)
        {
            int blobPointer = (int)p;
    
            tiff.BlobToVariant(ref blobVariant, blobPointer);
            tiff.WriteVToFile(ref blobVariant);
        }
    }
