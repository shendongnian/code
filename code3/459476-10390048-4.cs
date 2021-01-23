    // for the C# code to poll and read from C
    void ReadFromBuffer(char* pstrRet, UINT cbSize)
    {
        while (mutex>0);
        mutex++;
            
        if (cbSize > strlen(InteropBF)
        {
            strcpy(pstrRet, InteropBF);
        }
        else
        {
            //do some error
        }
        
        strcpy(InteropBF, "");
        mutex--;
    }
    
    //calling from c# 
    [DllImport ("CCNxPlugin")]
    public static extern void ReadFromBuffer(IntPtr pData, UInt32 cbData);
    .
    .
    . 
    String news;
    UInt32 cbData=INTEROP_BUFFER_SIZE; //you need to define this in c# ;)
    Byte[]  abyData=new byte[cbData]
    
    try
    {     
        //kindly request GC gives us a data address & leaves this memory alone for a bit
        GCHandle oGCHData = GCHandle.Alloc(abyData, GCHandleType.Pinned);
        IntPtr pbyData = oGCHData.AddrOfPinnedObject();
    
        ReadFromBuffer(pbyData, cbData);
    
        oGCHData.Free();
    
        news = BitConverter.ToString(abyData);
    }
    catch (Exception e)
    {
        System.Diagnostics.Debug.WriteLine(e);
    }
