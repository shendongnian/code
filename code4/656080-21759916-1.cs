    [ComImport, Guid("CCB91121-B81E-11D2-AB74-0040054C3719"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface COPOSMSR
    {
        void SOData([In] int Status);
        void SODirectIO([In] int EventNumber, [In, Out] ref int pData, [In, Out, MarshalAs(UnmanagedType.BStr)] ref string pStrIng);
        void SOError([In] int ResultCode, [In] int ResultCodeExtended, [In] int ErrorLocus, [In, Out] ref int pErrorResponse);
        void SOOutputCompleteDummy([In] int OutputID);
        void SOStatusUpdate([In] int Data);
        void SOProcessID([Out] out int pProcessID);
    }
