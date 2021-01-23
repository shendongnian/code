        public static class Helper
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern IntPtr GetCurrentThread();
    
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern bool ImpersonateAnonymousToken(IntPtr handle);
    
            public static void ImpersonateAnonymousUser()
            {            
                ImpersonateAnonymousToken(GetCurrentThread());
            }
        }
    
            static string ToString(IIdentity identity)
            {
                return string.Format("{0} {1} {2}", identity.Name, identity.IsAuthenticated, identity.AuthenticationType); 
            }
    
            static void Main(string[] args)
            {            
                Console.WriteLine(ToString(WindowsIdentity.GetCurrent()));
                Helper.ImpersonateAnonymousUser();
                Console.WriteLine(ToString(WindowsIdentity.GetCurrent()));
            }
