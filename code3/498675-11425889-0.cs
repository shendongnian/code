    using System.Security.Principal;
    using System.Security.Permissions;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.IO;
        
    public class ImpersonatedFileCopy : IDisposable
    {
        #region Assembly Functions
        [DllImport("advapi32.dll")]
        public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);
        #endregion
        #region Private Variables
        private IntPtr _TokenHandle = new IntPtr(0);
        private WindowsImpersonationContext _WindowsImpersonationContext;
        #endregion
        #region Constructors
        public ImpersonatedFileCopy(string domain, string username, string password)
        {
            Impersonate(domain, username, password);
        }
        #endregion
        #region Methods
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void Impersonate(string domain, string username, string password)
        {
            bool returnValue;
            try
            {
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_INTERACTIVE = 2;
                _TokenHandle = IntPtr.Zero;
                //Call LogonUser to obtain a handle to an access token.
                returnValue = LogonUser(username, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref _TokenHandle);
                if (returnValue)
                {
                    WindowsIdentity newId = new WindowsIdentity(_TokenHandle);
                    _WindowsImpersonationContext = newId.Impersonate();
                }
            }
            catch (Exception ex)
            {
                UndoImpersonate();
                Debug.Writeline("Error"+ex.Message);
            }
        }
        private void UndoImpersonate()
        {
            if (_WindowsImpersonationContext != null)
            {
                _WindowsImpersonationContext.Undo();
                if (!_TokenHandle.Equals(IntPtr.Zero))
                {
                    CloseHandle(_TokenHandle);
                }
            }
        }
        public bool PutFile(FileStream source, string destRemoteFilename, bool overwrite)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(destRemoteFilename))) Directory.CreateDirectory(Path.GetDirectoryName(destRemoteFilename));
                using (FileStream dest = File.OpenWrite(destRemoteFilename))
                {
                   source.Seek(0, SeekOrigin.Begin);
                   source.CopyTo(dest);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool GetFile(string sourceRemoteFilename, FileStream dest, bool overwrite)
        {
            try
            {
                using (FileStream source = File.OpenRead(sourceRemoteFilename))
                {
                    source.Seek(0, SeekOrigin.Begin);
                    source.CopyTo(dest);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region IDisposable
        public void Dispose()
        {
            UndoImpersonate();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
