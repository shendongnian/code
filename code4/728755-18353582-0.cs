    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)] // late binding only
    [Guid("00020400-0000-0000-C000-000000000046")] // IDispatch's GUID
    interface IMyLateBindingAdaptor
    {
        // a subset of IWebBrowser2 [http://msdn.microsoft.com/en-us/library/aa752127(v=vs.85).aspx]
        string LocationURL { get; }
        void Navigate(string url, ref object flags, ref object TargetFrameName, ref object PostData, ref object Headers);
    }
