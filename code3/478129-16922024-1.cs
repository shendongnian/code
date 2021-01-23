    var tmpFolder = _configManager.TmpFolder;
    bool isUnHandleException;
    //tranfer each image that's scann0ed and insert him to array,also dialogbox for a progress bar Indication  
    ArrayList pics = tw.TransferPictures(out isUnHandleException);
    EndingScan(); tw.CloseSrc();
    if (isUnHandleException)   ShowException(Consts.RestartWIA);
    string strFileName = "";
    // join all the images that's scanned  to one image tiff file
    var encoder = new TiffBitmapEncoder();
    BitmapFrame frame=null;
    Bitmap bp = null;
    IntPtr bmpptr,pixptr;
    if (!(pics != null && pics.Count != 0))
    {
        ShowException("No Has Any pages");
        return;
    }
    // create temp folder 
    CreateDirectory(tmpFolder);
    int picsCount = pics.Count;
    for (int i = 0; i < pics.Count; i++)
    {
        IntPtr img = (IntPtr)pics[i];
        //Locks a global memory object and returns a pointer to the first byte of the object's memory block 
        bmpptr = Twain.GlobalLock(img);
        //Get Pixel Info by handle
        pixptr = GdiWin32.GetPixelInfo(bmpptr);
        // create bitmap type
        bp = GdiWin32.BitmapFromDIB(bmpptr, pixptr);
        // get bitmap frame for insert him TiffBitmapEncoder
        frame = Imaging.GetBitmapFrame(bp);
        if (frame != null)
            encoder.Frames.Add(frame);
        //decease pointer reference so the gc will see there is no refernce to this obj and realse him from memory
        Twain.GlobalUnlock(img);
        // Get the last error and display it.
        //int error = Marshal.GetLastWin32Error();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    // genrate file name to temp folder 
    strFileName = GenerateFileTemp(tmpFolder);
    string strNewFileName = strFileName;
    _output = new FileStream(strNewFileName, FileMode.OpenOrCreate);
    encoder.Save(_output);
