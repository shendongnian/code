    public static class ProcessExtensions
    {
		const int INVALID_PID = -1;
		public static int GetParentPid(this Process process)
		{
			try
			{
				return ProcessInfo.GetProcessInfo(process.Handle).ParentPid.ToInt32();
			}
			catch
			{
				return INVALID_PID;
			}
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	struct ProcessInfo
	{
		// PROCESS_BASIC_INFORMATION
		public IntPtr ExitStatus;
		public IntPtr PebBaseAddress;
		public IntPtr AffinityMask;
		public IntPtr BasePriority;
		public IntPtr Pid;
		public IntPtr ParentPid;
		public static ProcessInfo GetProcessInfo(IntPtr handle)
		{
			var pbi = new ProcessInfo();
			int returnLength;
			var status = NtQueryInformationProcess(handle, 0, ref pbi, Marshal.SizeOf(pbi), out returnLength);
			if (status != 0)
				throw new Win32Exception(status);
			return pbi;
		}
		[DllImport("ntdll.dll")]
		static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass,
			ref ProcessInfo processInformation, int processInformationLength,
			out int returnLength);
	}
