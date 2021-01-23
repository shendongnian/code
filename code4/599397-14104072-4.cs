    [ComImport, Guid("D032F796-167D-4B0D-851D-2AEEA226646A"), 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMyDate
    {
        void Analyze_Date(ref int y, int m, int d); 
    }
