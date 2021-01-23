		public static IntPtr FindWindowByProcessId(int dwProcessId)
		{
			Process proc = Process.GetProcessById(dwProcessId);
			return proc.MainWindowHandle;
		}
