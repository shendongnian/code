    // for the C# code to poll and read from C
    unsigned int ReadFromBuffer(char* pstrRet, unsigned int cbSize)
    {
        unsigned int uiRet;
        while (mutex>0);
        mutex++;
        uiRet=strlen(InteropBF);
            
        if (uiRet > 0 && cbSize > uiRet) 
        {    
            strcpy(pstrRet, InteropBF);
        }
        else //error
        {        
            uiRet=0;
        }
        
        strcpy(InteropBF, "");
        mutex--;
        
        return uiRet;
    }
    
    //calling from c# 
    [DllImport ("CCNxPlugin")]
    public static extern UInt32 ReadFromBuffer(IntPtr pData, UInt32 cbData);
    .
    .
    . 
    String news;
    UInt32 cbData=INTEROP_BUFFER_SIZE; //you need to define this in c# ;)
    Byte[]  abyData=new byte[cbData];
    
    try
    {     
        //kindly request GC gives us a data address & leaves this memory alone for a bit
        GCHandle oGCHData = GCHandle.Alloc(abyData, GCHandleType.Pinned);
        IntPtr pbyData = oGCHData.AddrOfPinnedObject();
    
        UInt32 cbCopied=ReadFromBuffer(pbyData, cbData);
    
        oGCHData.Free();
    
        if(cbCopied > 0)
        { 
            System.Text.Encoding enc = System.Text.Encoding.ASCII;
            news = enc.GetString(abyData,0,cbCopied);
        }
    }
    catch (Exception e)
    {
        System.Diagnostics.Debug.WriteLine(e);
    }
