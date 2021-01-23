    private int onCallback(int lCode, int lParamSize, IntPtr pParam)
    {
           return 0;
    }
    XXXInterface.CallbackDelegate del = new XXXInterface.CallbackDelegate(onCallback);
    
    Console.Write(XXXInterface._Initialize("SomeFile.dat", del, 1000, "", 0, 4));
