     private static ManagementObject GetSecurityDescriptor()
     {
                ManagementObject Trustee = new ManagementClass(new ManagementPath("Win32_Trustee"), null);
                Trustee["SID"] = GetWellKnwonSid(WellKnownSidType.WorldSid);
                Trustee["Name"] = "Everyone";
    
                ManagementObject userACE = new ManagementClass(new ManagementPath("Win32_Ace"), null);
                userACE["AccessMask"] = 2032127;//Full access
                userACE["AceFlags"] = AceFlags.ObjectInherit | AceFlags.ContainerInherit;
                userACE["AceType"] = AceType.AccessAllowed;
                userACE["Trustee"] = Trustee;
    
                ManagementObject secDescriptor = new ManagementClass(new ManagementPath("Win32_SecurityDescriptor"), null);
                secDescriptor["ControlFlags"] = 4; //SE_DACL_PRESENT 
                secDescriptor["DACL"] = new object[] { userACE };
                secDescriptor["Group"] = Trustee;
                return secDescriptor;
      }
    private static byte[] GetWellKnwonSid(WellKnownSidType SidType)
    {
          SecurityIdentifier Result = new SecurityIdentifier(SidType, null);
          byte[] sidArray = new byte[Result.BinaryLength];
          Result.GetBinaryForm(sidArray, 0);
    
          return sidArray;
    }
