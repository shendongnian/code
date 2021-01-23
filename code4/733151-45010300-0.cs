    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Net;
    using System.Security.Principal;
    using System.Runtime.InteropServices;
    namespace IMPolicy
    {
    public partial class ExtractData : System.Web.UI.Page
    {
        [DllImport("advapi32.DLL", SetLastError = true)]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        protected void Page_Load(object sender, EventArgs e)
        {            
 
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
 
            IntPtr token = default(IntPtr);
            if (LogonUser("UserName", "Domain", "Password", 2, 0, ref token) != 0)
            {
 
                WindowsIdentity identity = new WindowsIdentity(token);
                WindowsImpersonationContext context = identity.Impersonate();
 
                try
                {                
                    File.Copy(@"\\\\10.10.38.25\d$\\Sourav\\Draft Report ITC-LRBD_Online Booking Portal_12082016.pdf", @"d:\\Draft Report ITC-LRBD_Online Booking Portal_12082016.pdf", true);
                 }
                 finally
                 {
                     context.Undo();
                 }
            }
 
            
 
        }
 
       
      }
    }
