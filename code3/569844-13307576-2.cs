    [ComVisible(true)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IStreamFrame
    {
        int     Width   { [return: MarshalAs(UnmanagedType.I4)]         get; }
        int     Height  { [return: MarshalAs(UnmanagedType.I4)]         get; }
        byte[]  Buffer  { [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VarEnum.VT_UI1)]  get; }
    };
    [ComVisible(false)]
    public delegate void StreamFrameCallback(IStreamFrame frame);
    
    [ComVisible(true)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IMyCOMStreamEvents
    {
        [DispId(1)]
        void OnStreamFrameCallback([In, MarshalAs(UnmanagedType.IDispatch)] IStreamFrame frame);
    }
