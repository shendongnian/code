	[StructLayoutAttribute(LayoutKind.Sequential)]
	struct SECURITY_DESCRIPTOR {
		public byte revision;
		public byte size;
		public short control;
		public IntPtr owner;
		public IntPtr group;
		public IntPtr sacl;
		public IntPtr dacl;
	}
	[DllImport("advapi32.dll", SetLastError = true)]
	static extern bool QueryServiceObjectSecurity(IntPtr serviceHandle, 
		System.Security.AccessControl.SecurityInfos secInfo, 
		ref SECURITY_DESCRIPTOR lpSecDesrBuf, 
		uint bufSize, 
		out uint bufSizeNeeded);
	[DllImport("advapi32.dll", SetLastError = true)]
	static extern bool QueryServiceObjectSecurity(SafeHandle serviceHandle, 
		System.Security.AccessControl.SecurityInfos secInfo, 
		byte[] lpSecDesrBuf, 
		uint bufSize, 
		out uint bufSizeNeeded);
	[DllImport("advapi32.dll", SetLastError = true)]
	static extern bool SetServiceObjectSecurity(SafeHandle serviceHandle, 
		System.Security.AccessControl.SecurityInfos secInfos, 
		byte[] lpSecDesrBuf);
	public void SetServicePermissions(string service, string username) {
		System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController(service, ".");
		ServiceControllerStatus status = sc.Status;
		byte[] psd = new byte[0];
		uint bufSizeNeeded;
		bool ok = QueryServiceObjectSecurity(sc.ServiceHandle, SecurityInfos.DiscretionaryAcl, psd, 0, out bufSizeNeeded);
		if (!ok) {
			int err = Marshal.GetLastWin32Error();
			if (err == 122 || err == 0) { // ERROR_INSUFFICIENT_BUFFER
				// expected; now we know bufsize
				psd = new byte[bufSizeNeeded];
				ok = QueryServiceObjectSecurity(sc.ServiceHandle, SecurityInfos.DiscretionaryAcl, psd, bufSizeNeeded, out bufSizeNeeded);
			} else {
				throw new ApplicationException("error calling QueryServiceObjectSecurity() to get DACL for " + _name + ": error code=" + err);
			}
		}
		if (!ok)
			throw new ApplicationException("error calling QueryServiceObjectSecurity(2) to get DACL for " + _name + ": error code=" + Marshal.GetLastWin32Error());
		// get security descriptor via raw into DACL form so ACE
		// ordering checks are done for us.
		RawSecurityDescriptor rsd = new RawSecurityDescriptor(psd, 0);
		RawAcl racl = rsd.DiscretionaryAcl;
		DiscretionaryAcl dacl = new DiscretionaryAcl(false, false, racl);
		// Add start/stop/read access
		NTAccount acct = new NTAccount(username);
		SecurityIdentifier sid = (SecurityIdentifier) acct.Translate(typeof(SecurityIdentifier));
		// 0xf7 is SERVICE_QUERY_CONFIG|SERVICE_CHANGE_CONFIG|SERVICE_QUERY_STATUS|
		// SERVICE_START|SERVICE_STOP|SERVICE_PAUSE_CONTINUE|SERVICE_INTERROGATE
		dacl.AddAccess(AccessControlType.Allow, sid, 0xf7, InheritanceFlags.None, PropagationFlags.None);
		// convert discretionary ACL back to raw form; looks like via byte[] is only way
		byte[] rawdacl = new byte[dacl.BinaryLength];
		dacl.GetBinaryForm(rawdacl, 0);
		rsd.DiscretionaryAcl = new RawAcl(rawdacl, 0);
		// set raw security descriptor on service again
		byte[] rawsd = new byte[rsd.BinaryLength];
		rsd.GetBinaryForm(rawsd, 0);
		ok = SetServiceObjectSecurity(sc.ServiceHandle, SecurityInfos.DiscretionaryAcl, rawsd);
		if (!ok) {
			throw new ApplicationException("error calling SetServiceObjectSecurity(); error code=" + Marshal.GetLastWin32Error());
		}
	}
