    using System.Runtime.InteropServices;
    ...
            [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00020400-0000-0000-C000-000000000046")]
            public interface IDispatch {
                int dummy1();
                int dummy2();
                int dummy3();
                [PreserveSig]
                int Invoke(int dispIdMember, ref Guid riid, int lcid, int dwFlags, 
                    [In, Out] stdole.DISPPARAMS pDispParams, 
                    [Out, MarshalAs(UnmanagedType.LPArray)] object[] pVarResult, 
                    [In, Out] stdole.EXCEPINFO pExcepInfo, 
                    [Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] pArgErr);
            }
