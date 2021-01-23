	class Program {
		const uint FSCTL_GET_OBJECT_ID=0x0009009c;
		public static String GetFileId(String path) {
			using(var fs=File.Open(
				path, 
				FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
				) {
				WinAPI.BY_HANDLE_FILE_INFORMATION info;
				WinAPI.GetFileInformationByHandle(fs.Handle, out info);
				return String.Format(
						"{0:x}", ((info.FileIndexHigh<<32)|info.FileIndexLow));
			}
		}
		public static WinAPI.FILE_OBJECTID_BUFFER GetFolderId(String path) {
			using(var hFile=WinAPI.CreateFile(
				path,
				WinAPI.GENERIC_READ, FileShare.Read,
				IntPtr.Zero,
				(FileMode)WinAPI.OPEN_EXISTING,
				WinAPI.FILE_FLAG_BACKUP_SEMANTICS,
				IntPtr.Zero
				)) {
				if(null==hFile||hFile.IsInvalid)
					throw new Win32Exception(Marshal.GetLastWin32Error());
				var buffer=default(WinAPI.FILE_OBJECTID_BUFFER);
				var nOutBufferSize=Marshal.SizeOf(buffer);
				var lpOutBuffer=Marshal.AllocHGlobal(nOutBufferSize);
				var lpBytesReturned=default(uint);
				var result=
					WinAPI.DeviceIoControl(
						hFile, FSCTL_GET_OBJECT_ID,
						IntPtr.Zero, 0,
						lpOutBuffer, nOutBufferSize,
						ref lpBytesReturned, IntPtr.Zero
						);
				if(!result)
					throw new Win32Exception(Marshal.GetLastWin32Error());
				var type=typeof(WinAPI.FILE_OBJECTID_BUFFER);
				buffer=(WinAPI.FILE_OBJECTID_BUFFER)
					Marshal.PtrToStructure(lpOutBuffer, type);
				Marshal.FreeHGlobal(lpOutBuffer);
				return buffer;
			}
		}
		public static void Main(String[] args) {
			Console.WriteLine(
				GetFileId(@"C:\Users\Matt\Desktop\TestDocument.txt"));
			var folderId=GetFolderId(@"C:\Users\Matt\Desktop");
			var objectId=folderId.ObjectId
					.Select(x => x.ToString("x2"))
					.Aggregate(String.Concat);
			Console.WriteLine("{0}", objectId);
		}
	}
	class WinAPI {
		internal const int
			GENERIC_READ=unchecked((int)0x80000000),
			FILE_FLAG_BACKUP_SEMANTICS=unchecked((int)0x02000000),
			OPEN_EXISTING=unchecked((int)3);
		[StructLayout(LayoutKind.Sequential)]
		public struct FILE_OBJECTID_BUFFER {
			public struct Union {
				[MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
				public byte[] BirthVolumeId;
				[MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
				public byte[] BirthObjectId;
				[MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
				public byte[] DomainId;
			}
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
			public byte[] ObjectId;
			public Union BirthInfo;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=48)]
			public byte[] ExtendedInfo;
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct BY_HANDLE_FILE_INFORMATION {
			public uint FileAttributes;
			public FILETIME CreationTime;
			public FILETIME LastAccessTime;
			public FILETIME LastWriteTime;
			public uint VolumeSerialNumber;
			public uint FileSizeHigh;
			public uint FileSizeLow;
			public uint NumberOfLinks;
			public uint FileIndexHigh;
			public uint FileIndexLow;
		}
		[DllImport("kernel32.dll", SetLastError=true)]
		public static extern bool DeviceIoControl(
			SafeFileHandle hDevice,
			uint dwIoControlCode,
			IntPtr lpInBuffer,
			uint nInBufferSize,
			[Out] IntPtr lpOutBuffer,
			int nOutBufferSize,
			ref uint lpBytesReturned,
			IntPtr lpOverlapped
			);
		[DllImport("kernel32.dll", SetLastError=true)]
		public static extern SafeFileHandle CreateFile(
			String fileName,
			int dwDesiredAccess,
			System.IO.FileShare dwShareMode,
			IntPtr securityAttrs_MustBeZero,
			System.IO.FileMode dwCreationDisposition,
			int dwFlagsAndAttributes,
			IntPtr hTemplateFile_MustBeZero
			);
		[DllImport("kernel32.dll", SetLastError=true)]
		public static extern bool GetFileInformationByHandle(
			IntPtr hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);
	}
