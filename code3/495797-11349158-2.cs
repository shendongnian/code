       internal sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
       {
          private SafeTokenHandle()
             : base(true)
          {
          }
       
          [DllImport("kernel32.dll")]
          [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
          [SuppressUnmanagedCodeSecurity]
          [return: MarshalAs(UnmanagedType.Bool)]
          private static extern bool CloseHandle(IntPtr handle);
          protected override bool ReleaseHandle()
          {
             return CloseHandle(handle);
          }
       }
