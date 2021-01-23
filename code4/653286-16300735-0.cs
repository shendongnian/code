    //assume this actually points to something (not zero!!)
    IntPtr pNative = IntPtr.Zero;
    
    //assume these are you image dimensions
    int w=640; //width
    int h=480; //height
    int ch =3; //channels
    
    //image loop
    //use unsafe
    //this is very fast!! 
    unsafe
    {
        for (int r = 0; r < h; r++)
        {
            byte* pI = (byte*)pNative.ToPointer() + r*w*ch; //pointer to start of row
            for (int c = 0; c < w; c++)
            {
                pI[c * ch]      = 0; //red
                pI[c * ch+1]    = 0; //green
                pI[c * ch+2]    = 0; //blue
    //also equivalent to *(pI + c*ch)  = 0 - i.e. using pointer arythmetic;
            }
        }
    }
