    [Guid("your GUID goes here")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]        
    public interface IRiskAssessment
    {
        [PreserveSig]                                            
        int Calculate(int i,double s);
    }
