      /// <summary>
            /// Authenticate the user, with windows auth(and domain) 
            /// If that fails then authenticate with forms
            /// If that fails...well, go to hell
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected void loginControl_Authenticate(object sender, AuthenticateEventArgs e) {
    
                //First try the windows login (domain+username / password)
                Logging.IntranetLogger.LogIntranetActionInfo(Logging.IntranetLogConst.Logging, Logging.IntranetLogConst.UserTryToLoggIn, loginControl.UserName);
    
                string domainName = GetDomainName(loginControl.UserName); // Extract domain name 
                //form provide DomainUsername e.g Domainname\Username
                string userName = GetUsername(loginControl.UserName);  // Extract user name 
                //from provided DomainUsername e.g Domainname\Username
                IntPtr token = IntPtr.Zero;
    
                //userName, domainName and Password parameters are very obvious.
                //dwLogonType (3rd parameter): 
                //    I used LOGON32_LOGON_INTERACTIVE, This logon type is 
                //    intended for users who will be interactively using the computer, 
                //    such as a user being logged on by a terminal server, remote shell, 
                //    or similar process. 
                //    This logon type has the additional expense of caching 
                //    logon information for disconnected operations.
                //    For more details about this parameter please see 
                //    http://msdn.microsoft.com/en-us/library/aa378184(VS.85).aspx
                //dwLogonProvider (4th parameter) :
                //    I used LOGON32_PROVIDER_DEFAUL, This provider use the standard 
                //    logon provider for the system. 
                //    The default security provider is negotiate, unless you pass 
                //    NULL for the domain name and the user name is not in UPN format. 
                //    In this case, the default provider is NTLM. For more details 
                //    about this parameter please see 
                //    http://msdn.microsoft.com/en-us/library/aa378184(VS.85).aspx
                //phToken (5th parameter):
                //    A pointer to a handle variable that receives a handle to a 
                //    token that represents the specified user. We can use this handler 
                //    for impersonation purpose. 
    
    
                //authenticate with the inputed 
                bool windowsLoginResult = LogonUser(userName, domainName, loginControl.Password, 2, 0, ref token);}
 
     [DllImport("ADVAPI32.dll", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Auto)]
    
     public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
