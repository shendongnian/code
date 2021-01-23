    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Security;
	public class ProcessHelper
	{
		static ProcessHelper()
		{
			UserToken = IntPtr.Zero;
		}
		private static IntPtr UserToken { get; set; }
		public int StartProcess(ProcessStartInfo processStartInfo)
		{
			LogInOtherUser(processStartInfo);
			Native.STARTUPINFO startUpInfo = new Native.STARTUPINFO();
			startUpInfo.cb = Marshal.SizeOf(startUpInfo);
			startUpInfo.lpDesktop = string.Empty;
			Native.PROCESS_INFORMATION processInfo = new Native.PROCESS_INFORMATION();
			bool processStarted = Native.CreateProcessAsUser(UserToken, processStartInfo.FileName, processStartInfo.Arguments,
															 IntPtr.Zero, IntPtr.Zero, true, 0, IntPtr.Zero, null,
															 ref startUpInfo, out processInfo);
			if (!processStarted)
			{
				throw new Win32Exception(Marshal.GetLastWin32Error());
			}
			uint processId = processInfo.dwProcessId;
			Native.CloseHandle(processInfo.hProcess);
			Native.CloseHandle(processInfo.hThread);
			return (int) processId;
		}
		private static void LogInOtherUser(ProcessStartInfo processStartInfo)
		{
			if (UserToken == IntPtr.Zero)
			{
				IntPtr tempUserToken = IntPtr.Zero;
				string password = SecureStringToString(processStartInfo.Password);
				bool loginResult = Native.LogonUser(processStartInfo.UserName, processStartInfo.Domain, password,
													Native.LOGON32_LOGON_BATCH, Native.LOGON32_PROVIDER_DEFAULT,
													ref tempUserToken);
				if (loginResult)
				{
					UserToken = tempUserToken;
				}
				else
				{
					Native.CloseHandle(tempUserToken);
					throw new Win32Exception(Marshal.GetLastWin32Error());
				}
			}
		}
		
		private static String SecureStringToString(SecureString value)
		{
			IntPtr stringPointer = Marshal.SecureStringToBSTR(value);
			try
			{
				return Marshal.PtrToStringBSTR(stringPointer);
			}
			finally
			{
				Marshal.FreeBSTR(stringPointer);
			}
		}
		public static void ReleaseUserToken()
		{
			Native.CloseHandle(UserToken);
		}
	}
	internal class Native
	{
		internal const int LOGON32_LOGON_INTERACTIVE = 2;
		internal const int LOGON32_LOGON_BATCH = 4;
		internal const int LOGON32_PROVIDER_DEFAULT = 0;
		[StructLayout(LayoutKind.Sequential)]
		internal struct PROCESS_INFORMATION
		{
			public IntPtr hProcess;
			public IntPtr hThread;
			public uint dwProcessId;
			public uint dwThreadId;
		}
		[StructLayout(LayoutKind.Sequential)]
		internal struct STARTUPINFO
		{
			public int cb;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpReserved;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpDesktop;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpTitle;
			public uint dwX;
			public uint dwY;
			public uint dwXSize;
			public uint dwYSize;
			public uint dwXCountChars;
			public uint dwYCountChars;
			public uint dwFillAttribute;
			public uint dwFlags;
			public short wShowWindow;
			public short cbReserved2;
			public IntPtr lpReserved2;
			public IntPtr hStdInput;
			public IntPtr hStdOutput;
			public IntPtr hStdError;
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct SECURITY_ATTRIBUTES
		{
			public System.UInt32 nLength;
			public IntPtr lpSecurityDescriptor;
			public bool bInheritHandle;
		}
		[DllImport("advapi32.dll", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
		internal extern static bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
		[DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUserA", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
		internal extern static bool CreateProcessAsUser(IntPtr hToken, [MarshalAs(UnmanagedType.LPStr)] string lpApplicationName, 
														[MarshalAs(UnmanagedType.LPStr)] string lpCommandLine, IntPtr lpProcessAttributes,
		                                                IntPtr lpThreadAttributes, bool bInheritHandle, uint dwCreationFlags, IntPtr lpEnvironment,
		                                                [MarshalAs(UnmanagedType.LPStr)] string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, 
														out PROCESS_INFORMATION lpProcessInformation);		
		[DllImport("kernel32.dll", EntryPoint = "CloseHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		internal extern static bool CloseHandle(IntPtr handle);
	}
