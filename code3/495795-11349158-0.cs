    public class ImpersonationMgr : IDisposable
      [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
      public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType,
                                          int dwLogonProvider, out SafeTokenHandle phToken);
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      public static extern bool CloseHandle(IntPtr handle);
      private const int LOGON32_PROVIDER_DEFAULT = 0;
      private const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
      private readonly string userName = string.Empty;
      private readonly string domainName = string.Empty;
      private readonly string password = string.Empty;
      private SafeTokenHandle safeTokenHandle = null;
      private WindowsImpersonationContext impersonatedUser = null;
      public ImpersonationMgr(string userName, string domainName, string password)
      {
         this.userName = userName;
         this.domainName = domainName;
         this.password = password;
      }
      public void BeginImpersonation()
      {
         bool returnValue = LogonUser(userName, domainName, password, LOGON32_LOGON_NEW_CREDENTIALS,
                                      LOGON32_PROVIDER_DEFAULT, out safeTokenHandle);
         if (returnValue == false)
         {
            int ret = Marshal.GetLastWin32Error();
            throw new System.ComponentModel.Win32Exception(ret);
         }
         impersonatedUser = WindowsIdentity.Impersonate(safeTokenHandle.DangerousGetHandle());
      }
      private void AssertImpersonationIsEnabled()
      {
         if(safeTokenHandle == null || impersonatedUser == null)
         {
            throw new UnauthorizedAccessException("You must call the BeginImpersonation method before attempting file write access.");
         }
      }
      public void WriteFile(string pathToFile, string fileContents)
      {
         AssertImpersonationIsEnabled();
         using (FileStream fileStream = File.Open(pathToFile, FileMode.CreateNew))
         {
            using (StreamWriter fileWriter = new StreamWriter(fileStream))
            {
               fileWriter.Write(fileContents);
            }
         }
      }
      public void WriteFile(string pathToFile, byte[] fileContents)
      {
         AssertImpersonationIsEnabled();
         using (FileStream fileStream = new FileStream(pathToFile, FileMode.Create))
         {
            fileStream .Write(fileContents, 0, fileContents.Length);
            fileStream .Flush();          
         }
      }
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
