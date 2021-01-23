    public static ServiceAccessFlags GetServiceAcces(ServiceController serviceController)
    {
      WindowsIdentity winId = WindowsIdentity.GetCurrent(TokenAccessLevels.Duplicate | TokenAccessLevels.Query);
      return GetServiceAcces(serviceController, winId);
    }
    
    private static ServiceAccessFlags GetServiceAcces(ServiceController serviceController, WindowsIdentity windowsIdentity)
    {
      // see http://www.pinvoke.net/default.aspx/advapi32/QueryServiceObjectSecurity.html?DelayRedirect=1If
      byte[] buffer = new byte[0];
      uint bufferSizeNeeded;
      bool ok = QueryServiceObjectSecurity(serviceController.ServiceHandle, SecurityInfos.DiscretionaryAcl, buffer, 0, out bufferSizeNeeded);
      if (!ok)
      {
    	int err = Marshal.GetLastWin32Error();
    	if (err == 122) // ERROR_INSUFFICIENT_BUFFER
    	{
    	  // expected; now we know bufsize
    	  buffer = new byte[bufferSizeNeeded];
    	  ok = QueryServiceObjectSecurity(serviceController.ServiceHandle, SecurityInfos.DiscretionaryAcl, buffer, bufferSizeNeeded, out bufferSizeNeeded);
    	}
    	else
    	{
    	  throw new InvalidOperationException("error calling QueryServiceObjectSecurity() to get DACL for Service: error code=" + err);
    	}
      }
      if (!ok)
    	throw new InvalidOperationException("error calling QueryServiceObjectSecurity(2) to get DACL for Service: error code=" + Marshal.GetLastWin32Error());
    
      RawSecurityDescriptor rsd = new RawSecurityDescriptor(buffer, 0);
      RawAcl racl = rsd.DiscretionaryAcl;
      DiscretionaryAcl dacl = new DiscretionaryAcl(false, false, racl);
    
      byte[] daclBuffer = new byte[dacl.BinaryLength];
      dacl.GetBinaryForm(daclBuffer, 0);
    
      SecurityIdentifier sid = windowsIdentity.User;
      byte[] sidBuffer = new byte[sid.BinaryLength];
      sid.GetBinaryForm(sidBuffer, 0);
    
      TRUSTEE t = new TRUSTEE();
      BuildTrusteeWithSid(ref t, sidBuffer);
    
      uint access = 0;
      uint hr = GetEffectiveRightsFromAcl(daclBuffer, ref t, ref access);
    
      ServiceAccessFlags serviceAccess = (ServiceAccessFlags)access;
    
      int i = Marshal.Release(t.ptstrName);
    
      return serviceAccess;
    }
    
    [DllImport("advapi32.dll")]
    private static extern uint GetEffectiveRightsFromAcl(byte[] pacl, ref TRUSTEE pTrustee, ref uint pAccessRights);
    
    private enum MULTIPLE_TRUSTEE_OPERATION
    {
      NO_MULTIPLE_TRUSTEE,
      TRUSTEE_IS_IMPERSONATE
    }
    
    private enum TRUSTEE_FORM
    {
      TRUSTEE_IS_SID,
      TRUSTEE_IS_NAME,
      TRUSTEE_BAD_FORM,
      TRUSTEE_IS_OBJECTS_AND_SID,
      TRUSTEE_IS_OBJECTS_AND_NAME
    }
    
    private enum TRUSTEE_TYPE
    {
      TRUSTEE_IS_UNKNOWN,
      TRUSTEE_IS_USER,
      TRUSTEE_IS_GROUP,
      TRUSTEE_IS_DOMAIN,
      TRUSTEE_IS_ALIAS,
      TRUSTEE_IS_WELL_KNOWN_GROUP,
      TRUSTEE_IS_DELETED,
      TRUSTEE_IS_INVALID,
      TRUSTEE_IS_COMPUTER
    }
    
    private struct TRUSTEE
    {
      public IntPtr pMultipleTrustee;
      public MULTIPLE_TRUSTEE_OPERATION MultipleTrusteeOperation;
      public TRUSTEE_FORM TrusteeForm;
      public TRUSTEE_TYPE TrusteeType;
      public IntPtr ptstrName;
    }
    
    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern void BuildTrusteeWithSid(
    	ref TRUSTEE pTrustee,
    	byte[] sid
    );
    
    [DllImport("advapi32.dll", SetLastError = true)]
    static extern bool QueryServiceObjectSecurity(SafeHandle serviceHandle, System.Security.AccessControl.SecurityInfos secInfo, byte[] lpSecDesrBuf, uint bufSize, out uint bufSizeNeeded);
    
    [System.FlagsAttribute]
    public enum ServiceAccessFlags : uint
    {
      QueryConfig = 1,
      ChangeConfig = 2,
      QueryStatus = 4,
      EnumerateDependents = 8,
      Start = 16,
      Stop = 32,
      PauseContinue = 64,
      Interrogate = 128,
      UserDefinedControl = 256,
      Delete = 65536,
      ReadControl = 131072,
      WriteDac = 262144,
      WriteOwner = 524288,
      Synchronize = 1048576,
      AccessSystemSecurity = 16777216,
      GenericAll = 268435456,
      GenericExecute = 536870912,
      GenericWrite = 1073741824,
      GenericRead = 2147483648
    }
