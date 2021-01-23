        public static bool GetImpersonationToken(string UPN, out IntPtr dupToken)
        {
            dupToken = IntPtr.Zero;
            WindowsImpersonationContext impersonationContext = null;
            bool result = false;
            try
            {
                WindowsIdentity wid = new WindowsIdentity(UPN);
                impersonationContext = wid.Impersonate();
                result = DuplicateToken(wid.Token, 2, ref dupToken) != 0;
            }
            finally
            {
                if (impersonationContext != null)
                    impersonationContext.Undo();
            }
            return result;
        }
