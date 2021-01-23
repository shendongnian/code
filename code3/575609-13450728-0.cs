    	using System;
		using System.Collections.Generic;
		using System.Text;
		using System.Runtime.InteropServices;
		namespace SetFileTime
		{
			class Win32Setfiletime
			{
				[StructLayout(LayoutKind.Sequential)]
				struct FILETIME
				{
					public uint DateTimeLow;
					public uint DateTimeHigh;
				}
				[StructLayout(LayoutKind.Sequential)]
				struct SYSTEMTIME
				{
					[MarshalAs(UnmanagedType.U2)]
					public short Year;
					[MarshalAs(UnmanagedType.U2)]
					public short Month;
					[MarshalAs(UnmanagedType.U2)]
					public short DayOfWeek;
					[MarshalAs(UnmanagedType.U2)]
					public short Day;
					[MarshalAs(UnmanagedType.U2)]
					public short Hour;
					[MarshalAs(UnmanagedType.U2)]
					public short Minute;
					[MarshalAs(UnmanagedType.U2)]
					public short Second;
					[MarshalAs(UnmanagedType.U2)]
					public short Milliseconds;
					public SYSTEMTIME(DateTime dt)
					{
						dt = dt.ToUniversalTime();  // SetSystemTime expects the SYSTEMTIME in UTC
						Year = (short)dt.Year;
						Month = (short)dt.Month;
						DayOfWeek = (short)dt.DayOfWeek;
						Day = (short)dt.Day;
						Hour = (short)dt.Hour;
						Minute = (short)dt.Minute;
						Second = (short)dt.Second;
						Milliseconds = (short)dt.Millisecond;
					}
				}
				static DateTime getDateTime(SYSTEMTIME systemTime)
				{
					DateTime dt = new DateTime(systemTime.Year, systemTime.Month, systemTime.Day, systemTime.Hour, systemTime.Minute, systemTime.Second);
					return dt;
				}
				static SYSTEMTIME getSystemTime(DateTime dt)
				{
					SYSTEMTIME st = new SYSTEMTIME(dt);
					return st;
				}
				static FILETIME getFileTime(DateTime dt)
				{
					FILETIME ft = new FILETIME();
					SYSTEMTIME st = new SYSTEMTIME(dt);
					SystemTimeToFileTime(ref st, ref ft);
					return ft;
				}
				[DllImport("coredll.dll", EntryPoint = "SystemTimeToFileTime", SetLastError = true)]
				static extern bool SystemTimeToFileTime(ref SYSTEMTIME lpSystemTime, ref FILETIME lpFileTime);
				[DllImport("coredll.dll", SetLastError = true)]
				static extern bool FileTimeToSystemTime([In] ref FILETIME lpFileTime,out SYSTEMTIME lpSystemTime);
				[DllImport("coredll.dll")]
				static extern bool FileTimeToLocalFileTime([In] ref FILETIME lpFileTime, out FILETIME lpLocalFileTime);
				[DllImport("coredll.dll", SetLastError = true)]
				[return: MarshalAs(UnmanagedType.Bool)]
				static extern bool SetFileTime(IntPtr hFile, ref FILETIME lpCreationTime, ref FILETIME lpLastAccessTime, ref FILETIME lpLastWriteTime);
				[DllImport("coredll.dll")]
				static extern bool GetFileTime(IntPtr hFile, ref FILETIME lpCreationTime, ref FILETIME lpLastAccessTime, ref FILETIME lpLastWriteTime);
				[DllImport("coredll", SetLastError = true)]
				static extern IntPtr CreateFile(String lpFileName, EFileAccess dwDesiredAccess, EFileShare dwShareMode, IntPtr lpSecurityAttributes, ECreationDisposition dwCreationDisposition, EFileAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);
				#region "constants"
				[Flags]
				enum EFileAccess : uint
				{
					//
					// Standart Section
					//
					AccessSystemSecurity = 0x1000000,   // AccessSystemAcl access type
					MaximumAllowed = 0x2000000,     // MaximumAllowed access type
					Delete = 0x10000,
					ReadControl = 0x20000,
					WriteDAC = 0x40000,
					WriteOwner = 0x80000,
					Synchronize = 0x100000,
					StandardRightsRequired = 0xF0000,
					StandardRightsRead = ReadControl,
					StandardRightsWrite = ReadControl,
					StandardRightsExecute = ReadControl,
					StandardRightsAll = 0x1F0000,
					SpecificRightsAll = 0xFFFF,
					FILE_READ_DATA = 0x0001,        // file & pipe
					FILE_LIST_DIRECTORY = 0x0001,       // directory
					FILE_WRITE_DATA = 0x0002,       // file & pipe
					FILE_ADD_FILE = 0x0002,         // directory
					FILE_APPEND_DATA = 0x0004,      // file
					FILE_ADD_SUBDIRECTORY = 0x0004,     // directory
					FILE_CREATE_PIPE_INSTANCE = 0x0004, // named pipe
					FILE_READ_EA = 0x0008,          // file & directory
					FILE_WRITE_EA = 0x0010,         // file & directory
					FILE_EXECUTE = 0x0020,          // file
					FILE_TRAVERSE = 0x0020,         // directory
					FILE_DELETE_CHILD = 0x0040,     // directory
					FILE_READ_ATTRIBUTES = 0x0080,      // all
					FILE_WRITE_ATTRIBUTES = 0x0100,     // all
					//
					// Generic Section
					//
					GenericRead = 0x80000000,
					GenericWrite = 0x40000000,
					GenericExecute = 0x20000000,
					GenericAll = 0x10000000,
					SPECIFIC_RIGHTS_ALL = 0x00FFFF,
					FILE_ALL_ACCESS =
					StandardRightsRequired |
					Synchronize |
					0x1FF,
					FILE_GENERIC_READ =
					StandardRightsRead |
					FILE_READ_DATA |
					FILE_READ_ATTRIBUTES |
					FILE_READ_EA |
					Synchronize,
					FILE_GENERIC_WRITE =
					StandardRightsWrite |
					FILE_WRITE_DATA |
					FILE_WRITE_ATTRIBUTES |
					FILE_WRITE_EA |
					FILE_APPEND_DATA |
					Synchronize,
					FILE_GENERIC_EXECUTE =
					StandardRightsExecute |
					  FILE_READ_ATTRIBUTES |
					  FILE_EXECUTE |
					  Synchronize
				}
				[Flags]
				public enum EFileShare : uint
				{
					/// <summary>
					///
					/// </summary>
					None = 0x00000000,
					/// <summary>
					/// Enables subsequent open operations on an object to request read access.
					/// Otherwise, other processes cannot open the object if they request read access.
					/// If this flag is not specified, but the object has been opened for read access, the function fails.
					/// </summary>
					Read = 0x00000001,
					/// <summary>
					/// Enables subsequent open operations on an object to request write access.
					/// Otherwise, other processes cannot open the object if they request write access.
					/// If this flag is not specified, but the object has been opened for write access, the function fails.
					/// </summary>
					Write = 0x00000002,
					/// <summary>
					/// Enables subsequent open operations on an object to request delete access.
					/// Otherwise, other processes cannot open the object if they request delete access.
					/// If this flag is not specified, but the object has been opened for delete access, the function fails.
					/// </summary>
					Delete = 0x00000004
				}
				enum ECreationDisposition : uint
				{
					/// <summary>
					/// Creates a new file. The function fails if a specified file exists.
					/// </summary>
					New = 1,
					/// <summary>
					/// Creates a new file, always.
					/// If a file exists, the function overwrites the file, clears the existing attributes, combines the specified file attributes,
					/// and flags with FILE_ATTRIBUTE_ARCHIVE, but does not set the security descriptor that the SECURITY_ATTRIBUTES structure specifies.
					/// </summary>
					CreateAlways = 2,
					/// <summary>
					/// Opens a file. The function fails if the file does not exist.
					/// </summary>
					OpenExisting = 3,
					/// <summary>
					/// Opens a file, always.
					/// If a file does not exist, the function creates a file as if dwCreationDisposition is CREATE_NEW.
					/// </summary>
					OpenAlways = 4,
					/// <summary>
					/// Opens a file and truncates it so that its size is 0 (zero) bytes. The function fails if the file does not exist.
					/// The calling process must open the file with the GENERIC_WRITE access right.
					/// </summary>
					TruncateExisting = 5
				}
				[Flags]
				enum EFileAttributes : uint
				{
					Readonly = 0x00000001,
					Hidden = 0x00000002,
					System = 0x00000004,
					Directory = 0x00000010,
					Archive = 0x00000020,
					Device = 0x00000040,
					Normal = 0x00000080,
					Temporary = 0x00000100,
					SparseFile = 0x00000200,
					ReparsePoint = 0x00000400,
					Compressed = 0x00000800,
					Offline = 0x00001000,
					NotContentIndexed = 0x00002000,
					Encrypted = 0x00004000,
					Write_Through = 0x80000000,
					Overlapped = 0x40000000,
					NoBuffering = 0x20000000,
					RandomAccess = 0x10000000,
					SequentialScan = 0x08000000,
					DeleteOnClose = 0x04000000,
					BackupSemantics = 0x02000000,
					PosixSemantics = 0x01000000,
					OpenReparsePoint = 0x00200000,
					OpenNoRecall = 0x00100000,
					FirstPipeInstance = 0x00080000
				}
				#endregion
				public static DateTime getFileTime(string sFile)
				{
					DateTime dt = new DateTime();
					IntPtr hFile = CreateFile(sFile,EFileAccess.FILE_GENERIC_READ, EFileShare.Write, IntPtr.Zero,ECreationDisposition.OpenExisting, EFileAttributes.Normal, IntPtr.Zero);
					if (hFile != IntPtr.Zero)
					{
						FILETIME ftCreation = new FILETIME();
						FILETIME ftLastAccess=new FILETIME();
						FILETIME ftLastWrite=new FILETIME();
						if (GetFileTime(hFile, ref ftCreation, ref ftLastAccess, ref ftLastWrite))
						{
							SYSTEMTIME st=new SYSTEMTIME();
							if (FileTimeToSystemTime(ref ftLastAccess, out st))
								dt = getDateTime(st);
						}
					}
					return dt;
				}
				public static bool setLastWrite(string sFile, DateTime dt)
				{
					bool bRet = false;
					IntPtr hFile = CreateFile(sFile,EFileAccess.FILE_GENERIC_READ, EFileShare.Write, IntPtr.Zero,ECreationDisposition.OpenExisting, EFileAttributes.Normal, IntPtr.Zero);
					if (hFile != null)
					{
						FILETIME ftCreation = new FILETIME();
						FILETIME ftLastAccess=new FILETIME();
						FILETIME ftLastWrite=new FILETIME();
						if (GetFileTime(hFile, ref ftCreation, ref ftLastAccess, ref ftLastWrite))
						{
							FILETIME ftNewLastWrite= new FILETIME();
							ftNewLastWrite=getFileTime(dt);
							SetFileTime(hFile, ref ftCreation, ref ftLastAccess, ref ftNewLastWrite);
						}
					}
					return bRet;
				}
			}
		}
