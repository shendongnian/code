    public static unsafe SIMDVector4 operator *( SIMDVector4 a, SIMDVector4 b )
        {
          GCHandle aHandle = GCHandle.Alloc(a, GCHandleType.Pinned);
          GCHandle bHandle = GCHandle.Alloc(b, GCHandleType.Pinned);
            SIMDVector4Mult( aHandle.ToIntPtr(), bHandle.ToIntPtr() );
    aHandle.Free();
    bHandle.Free();
    
            return a;
        }
    [DllImport("SIMDMathLibrary.dll", CallingConvention = CallingConvention.Cdecl )]
        extern private static unsafe void SIMDVector4Mult(IntPtr a, IntPtr b );
