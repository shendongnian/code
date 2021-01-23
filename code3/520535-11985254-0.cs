    [ComImport, Guid("EA5435EA-AA5C-455d-BF97-5F19DC9C29AD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IClosedCaptionsDecoder2 
    {
        // Methods inherited from IClosedCaptionsDecoder:
        [PreserveSig]
        int xxx(whatever...);
        // Methods specific to IClosedCaptionsDecoder2
        [PreserveSig]
        int SetConfig([In] ref ClosedCaptionsDecoderConfig config);
        [PreserveSig]
        int GetConfig([Out] out ClosedCaptionsDecoderConfig config);
    }
