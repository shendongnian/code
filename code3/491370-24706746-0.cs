	public class ActiveDirectoryHelper
	{
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool LogonUser(
			string lpszUsername,
			string lpszDomain,
			string lpszPassword,
			int dwLogonType,
			int dwLogonProvider,
			out IntPtr phToken
			);
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);
		public static bool Authenticate(string userName, string password, string domain)
		{
			IntPtr token;
			LogonUser(userName, domain, password, 2, 0, out token);
			bool isAuthenticated = token != IntPtr.Zero;
			CloseHandle(token);
			return isAuthenticated;
		}
		public static IntPtr GetAuthenticationHandle(string userName, string password, string domain)
		{
			IntPtr token;
			LogonUser(userName, domain, password, 2, 0, out token);
			return token;
		}
	}
