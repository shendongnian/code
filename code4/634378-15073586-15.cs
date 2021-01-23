	namespace DiskManagement {
		using Microsoft.Win32.SafeHandles;
		using LPSECURITY_ATTRIBUTES=IntPtr;
		using LPOVERLAPPED=IntPtr;
		using LPVOID=IntPtr;
		using HANDLE=IntPtr;
		using LARGE_INTEGER=Int64;
		using DWORD=UInt32;
		using LPCTSTR=String;
		public static partial class IoCtl /* methods */ {
			[DllImport("kernel32.dll", SetLastError=true)]
			static extern SafeFileHandle CreateFile(
				LPCTSTR lpFileName,
				DWORD dwDesiredAccess,
				DWORD dwShareMode,
				LPSECURITY_ATTRIBUTES lpSecurityAttributes,
				DWORD dwCreationDisposition,
				DWORD dwFlagsAndAttributes,
				HANDLE hTemplateFile
				);
			[DllImport("kernel32.dll", SetLastError=true)]
			static extern DWORD DeviceIoControl(
				SafeFileHandle hDevice,
				DWORD dwIoControlCode,
				LPVOID lpInBuffer,
				DWORD nInBufferSize,
				LPVOID lpOutBuffer,
				int nOutBufferSize,
				ref DWORD lpBytesReturned,
				LPOVERLAPPED lpOverlapped
				);
			static DWORD CTL_CODE(DWORD DeviceType, DWORD Function, DWORD Method, DWORD Access) {
				return (((DeviceType)<<16)|((Access)<<14)|((Function)<<2)|(Method));
			}
			public static void Execute<T>(
				ref T x,
				DWORD dwIoControlCode,
				LPCTSTR lpFileName,
				DWORD dwDesiredAccess=GENERIC_READ,
				DWORD dwShareMode=FILE_SHARE_WRITE|FILE_SHARE_READ,
				LPSECURITY_ATTRIBUTES lpSecurityAttributes=default(LPSECURITY_ATTRIBUTES),
				DWORD dwCreationDisposition=OPEN_EXISTING,
				DWORD dwFlagsAndAttributes=0,
				HANDLE hTemplateFile=default(IntPtr)
				) {
				using(
					var hDevice=
						CreateFile(
							lpFileName,
							dwDesiredAccess, dwShareMode,
							lpSecurityAttributes,
							dwCreationDisposition, dwFlagsAndAttributes,
							hTemplateFile
							)
					) {
					if(null==hDevice||hDevice.IsInvalid)
						throw new Win32Exception(Marshal.GetLastWin32Error());
					var nOutBufferSize=Marshal.SizeOf(typeof(T));
					var lpOutBuffer=Marshal.AllocHGlobal(nOutBufferSize);
					var lpBytesReturned=default(DWORD);
					var NULL=IntPtr.Zero;
					var result=
						DeviceIoControl(
							hDevice, dwIoControlCode,
							NULL, 0,
							lpOutBuffer, nOutBufferSize,
							ref lpBytesReturned, NULL
							);
					if(0==result)
						throw new Win32Exception(Marshal.GetLastWin32Error());
					x=(T)Marshal.PtrToStructure(lpOutBuffer, typeof(T));
					Marshal.FreeHGlobal(lpOutBuffer);
				}
			}
		}
		public enum MEDIA_TYPE: int {
			Unknown=0,
			F5_1Pt2_512=1,
			F3_1Pt44_512=2,
			F3_2Pt88_512=3,
			F3_20Pt8_512=4,
			F3_720_512=5,
			F5_360_512=6,
			F5_320_512=7,
			F5_320_1024=8,
			F5_180_512=9,
			F5_160_512=10,
			RemovableMedia=11,
			FixedMedia=12,
			F3_120M_512=13,
			F3_640_512=14,
			F5_640_512=15,
			F5_720_512=16,
			F3_1Pt2_512=17,
			F3_1Pt23_1024=18,
			F5_1Pt23_1024=19,
			F3_128Mb_512=20,
			F3_230Mb_512=21,
			F8_256_128=22,
			F3_200Mb_512=23,
			F3_240M_512=24,
			F3_32M_512=25
		}
		partial class DiskGeometry /* structures */ {
			[StructLayout(LayoutKind.Sequential)]
			struct DISK_GEOMETRY {
				internal LARGE_INTEGER Cylinders;
				internal MEDIA_TYPE MediaType;
				internal DWORD TracksPerCylinder;
				internal DWORD SectorsPerTrack;
				internal DWORD BytesPerSector;
			}
			[StructLayout(LayoutKind.Sequential)]
			struct DISK_GEOMETRY_EX {
				internal DISK_GEOMETRY Geometry;
				internal LARGE_INTEGER DiskSize;
				[MarshalAs(UnmanagedType.ByValArray, SizeConst=1)]
				internal byte[] Data;
			}
		}
		partial class DiskGeometry /* properties and fields */ {
			public MEDIA_TYPE MediaType {
				get {
					return m_Geometry.MediaType;
				}
			}
			public String MediaTypeName {
				get {
					return Enum.GetName(typeof(MEDIA_TYPE), this.MediaType);
				}
			}
			public override long Cylinder {
				get {
					return m_Geometry.Cylinders;
				}
			}
			public override uint Head {
				get {
					return m_Geometry.TracksPerCylinder;
				}
			}
			public override uint Sector {
				get {
					return m_Geometry.SectorsPerTrack;
				}
			}
			public DWORD BytesPerSector {
				get {
					return m_Geometry.BytesPerSector;
				}
			}
			public long DiskSize {
				get {
					return m_DiskSize;
				}
			}
			public long MaximumLinearAddress {
				get {
					return m_MaximumLinearAddress;
				}
			}
			public CubicAddress MaximumCubicAddress {
				get {
					return m_MaximumCubicAddress;
				}
			}
			public DWORD BytesPerCylinder {
				get {
					return m_BytesPerCylinder;
				}
			}
			CubicAddress m_MaximumCubicAddress;
			long m_MaximumLinearAddress;
			DWORD m_BytesPerCylinder;
			LARGE_INTEGER m_DiskSize;
			DISK_GEOMETRY m_Geometry;
		}
	}
