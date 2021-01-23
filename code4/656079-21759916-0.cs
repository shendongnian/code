    [ComVisible(true), Guid("Put a GUID here")]
    public interface IMSR
    {
        //Common Opos
        [DispId(0x01)]
        int CheckHealth([In] int lLevel);
        [DispId(0x02)]
        int ClaimDevice([In] int lTimeOut);
        [DispId(0x03)]
        int ClearInput();
        [DispId(0x04)]
        int ClearInputProperties();
        [DispId(0x05)]
        int ClearOutput();
        [DispId(0x06)]
        int CloseService();
        [DispId(0x07)]
        int COFreezeEvents([In, MarshalAs(UnmanagedType.VariantBool)] bool Freeze);
        [DispId(0x08)]
        int CompareFirmwareVersion([In, MarshalAs(UnmanagedType.BStr)] string FirmwareFileName, [In, Out]ref int pResult);
        [DispId(0x09)]
        int DirectIO([In] int lCommand, [In, Out] ref int pData, [In, Out, MarshalAs(UnmanagedType.BStr)] ref string pString);
        [DispId(0x0A)]
        int OpenService([In, MarshalAs(UnmanagedType.BStr)] string lpclDevClass, [In, MarshalAs(UnmanagedType.BStr)] string lpclDevName, [In, MarshalAs(UnmanagedType.IDispatch)] object lpDispatch);
        [DispId(0x0B)]
        int ReleaseDevice();
        [DispId(0x0C)]
        int ResetStatistics([In, MarshalAs(UnmanagedType.BStr)] string StatisticsBuffer);
        [DispId(0x0D)]
        int RetrieveStatistics([In, Out, MarshalAs(UnmanagedType.BStr)] ref string pStatisticsBuffer);
        [DispId(0x0E)]
        int UpdateFirmware([In, MarshalAs(UnmanagedType.BStr)] string FirmwareFileName);
        [DispId(0x0F)]
        int UpdateStatistics([In, MarshalAs(UnmanagedType.BStr)] string StatisticsBuffer);
        [DispId(0x10)]
        int GetPropertyNumber([In] int lPropIndex);
        [DispId(0x11)]
        string GetPropertyString([In] int lPropIndex);
        [DispId(0x12)]
        void SetPropertyNumber([In] int lPropIndex, [In] int nNewValue);
        [DispId(0x13)]
        void SetPropertyString([In] int lPropIndex, [In, MarshalAs(UnmanagedType.BStr)] string StringData);
        //MSR Specific
        [DispId(0x14)]
        int AuthenticateDevice([In, MarshalAs(UnmanagedType.BStr)] string deviceResponse);
        [DispId(0x15)]
        int DeauthenticateDevice([In, MarshalAs(UnmanagedType.BStr)] string deviceResponse);
        [DispId(0x16)]
        int RetrieveCardProperty([In, MarshalAs(UnmanagedType.BStr)] string propertyName, [Out, MarshalAs(UnmanagedType.BStr)] out string cardProperty);
        [DispId(0x17)]
        int RetrieveDeviceAuthenticationData([In, Out, MarshalAs(UnmanagedType.BStr)] ref string challenge);
        [DispId(0x18)]
        int UpdateKey([In, MarshalAs(UnmanagedType.BStr)]string key,[In, MarshalAs(UnmanagedType.BStr)] string keyName);
        [DispId(0x19)]
        int WriteTracks([In] object data,[In] int timeout);
    }
