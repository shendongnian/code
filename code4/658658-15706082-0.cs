    class Impersonator : IDisposable
      {
          [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
          private static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
              int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
      
          [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
          private extern static bool CloseHandle(IntPtr handle);
      
          WindowsIdentity newId;
          WindowsImpersonationContext impersonatedUser;
          private bool isDisposed;
      
          public Impersonator(string user, string password, string domain)
          {
              SafeTokenHandle safeTokenHandle;
              const int LOGON32_PROVIDER_DEFAULT = 0;
              //This parameter causes LogonUser to create a primary token. 
              const int LOGON32_LOGON_INTERACTIVE = 2;
      
              // Call LogonUser to obtain a handle to an access token. 
              bool returnValue = LogonUser(user, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out safeTokenHandle);
      
              newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
              impersonatedUser = newId.Impersonate();
          }
      
          public void Dispose()
          {
      
              this.Dispose(true);
              GC.SuppressFinalize(this);
          }
      
          public void Dispose(bool disposing)
          {
              if (!this.isDisposed)
              {
                  if (disposing)
                  {
                      if (impersonatedUser != null)
                      {
                          this.impersonatedUser.Dispose();
                      }
      
                      if (newId != null)
                      {
                          this.newId.Dispose();
                      }
                  }
              }
      
              this.isDisposed = true;
          }
      
          ~Impersonator()
          {
              Dispose(false);
          }
      
          private sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
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
      }
