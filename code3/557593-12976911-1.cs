    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("22341123-9264-12AB-C1A4-B4F112014C31")]
    public interface IComExposed
    {        
        double[] DoubleArray {
            [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VT_R8)]
            get;
            [param: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VT_R8)]
            set; 
        }
        object[] ObjectArray { get; set; }
        object PlainObject { get; set; }
        double ScalarDouble { get; set; }
    }
