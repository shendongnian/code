        [DllImport("Advapi32.dll")]
        static extern bool GetSecurityDescriptorOwner(
           [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)]
           Int32[] securityDescriptor,
           [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)] 
           out Byte[] owner,
           out Boolean defaulted);
        
        [DllImport("Advapi32.dll")]
        static extern bool IsValidSecurityDescriptor(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] 
            Int32[] securityDescriptor);
        private static SecurityIdentifier GetSecurityIdentifier()
        {
            // Allocate managed buffer for invalid security descriptor structure (20 bytes)
            Int32[] b = new[] { 1, 1, 1, 1, 1 };
            Byte[] ownerSid;
            bool defaulted;
            if (IsValidSecurityDescriptor(b) &&
                GetSecurityDescriptorOwner(b, out ownerSid, out defaulted))
            {
                return new SecurityIdentifier(ownerSid, 0);
            }
            return null;
        }
        static void Main()
        {
            for (Int32 index = 0; index < 1000; index++)
            {
                SecurityIdentifier identifier = GetSecurityIdentifier();
                String text = identifier == null ? "(none)" : identifier.Value;
                Console.WriteLine(text);
            }
            Console.ReadKey();
        }
