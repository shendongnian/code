    /// Return Type: int
    ///param0: int
    ///param1: int
    ///param2: double*
    ///param3: double*
    ///param4: int*
    public delegate int Anonymous_83fd32fd_91ee_45ce_b7e9_b7d886d2eb38(int param0, int param1, ref double param2, ref double param3, ref int param4);
    
    public partial class NativeMethods {
        
        /// Return Type: int
        ///fcn: Anonymous_83fd32fd_91ee_45ce_b7e9_b7d886d2eb38
        ///m: int
        ///n: int
        ///x: double*
        ///ftol: double
        ///xtol: double
        ///gtol: double
        ///maxfev: int
        ///epsfcn: double
        ///factor: double
        [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="lmdif", CallingConvention=System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public static extern  int lmdif(Anonymous_83fd32fd_91ee_45ce_b7e9_b7d886d2eb38 fcn, int m, int n, ref double x, double ftol, double xtol, double gtol, int maxfev, double epsfcn, double factor) ;
    
    }
