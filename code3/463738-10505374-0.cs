        static void Main()
        {
            GrantAccess()
        }
        private static bool GrantAccess()
        {
            FileInfo fInfo = new FileInfo(Assembly.GetEntryAssembly().Location + ".config");
            FileSecurity dSecurity = fInfo .GetAccessControl();
            fSecurity.AddAccessRule(new FileSystemAccessRule("everyone", 
                                                             FileSystemRights.FullControl, 
                                                             AccessControlType.Allow));
            fInfo .SetAccessControl(fSecurity);
            return true;
        }
