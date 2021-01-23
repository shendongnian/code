    [ComImport]
    [Guid("F490EB00-1240-11D1-9888-006097DEACF9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IActiveDesktop
    {
         [PreserveSig]
         int ApplyChanges(AD_Apply dwFlags);
         // [...]
         // Note: There is a lot more to this interface,
         //        please see PInvoke.net link below.
    }
    private const int AD_APPLY_REFRESH = 4;
    
    IActiveDesktop.ApplyChanges(AD_APPLY_REFRESH);
