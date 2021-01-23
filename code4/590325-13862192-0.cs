    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet=CharSet.Ansi)]
    public struct Event
    {
        [MarshalAs(UnmanagedType.I4)]
        public int event_type;
    
        [MarshalAs(UnmanagedType.R8)]
        public double time_stamp;
    
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
        public string event_text;
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate Status GetEventList([out]Event[] eventList);
    
    public Event[] GetEventList()
    {
        // this.pDll is a pointer to the dll library.
        IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(this.pDll, "GetEventList");
        GetEventList getEventList = (GetEventList)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(GetEventList));
    
        Event[] eventList = new Event[2];
        getEventList(eventList);
    
        return eventList;
    }
