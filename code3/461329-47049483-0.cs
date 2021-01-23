	using System.Runtime.InteropServices;
	using System.Runtime.CompilerServices;
	using static System.Runtime.CompilerServices.MethodImplOptions;
	/// <summary> Gets the position of the right most non-zero bit in a UInt32.  </summary>
	[MethodImpl(AggressiveInlining)] public static int BitScanForward(UInt32 mask) => _BitScanForward32(mask);
	/// <summary> Gets the position of the left most non-zero bit in a UInt32.  </summary>
	[MethodImpl(AggressiveInlining)] public static int BitScanReverse(UInt32 mask) => _BitScanReverse32(mask);
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
	private static TDelegate GenerateX86Function<TDelegate>(byte[] x86AssemblyBytes) {
		const uint PAGE_EXECUTE_READWRITE = 0x40;
		const uint ALLOCATIONTYPE_MEM_COMMIT = 0x1000;
		const uint ALLOCATIONTYPE_RESERVE = 0x2000;
		const uint ALLOCATIONTYPE = ALLOCATIONTYPE_MEM_COMMIT | ALLOCATIONTYPE_RESERVE;
		IntPtr buf = VirtualAlloc(IntPtr.Zero, (uint)x86AssemblyBytes.Length, ALLOCATIONTYPE, PAGE_EXECUTE_READWRITE);
		Marshal.Copy(x86AssemblyBytes, 0, buf, x86AssemblyBytes.Length);
		return (TDelegate)(object)Marshal.GetDelegateForFunctionPointer(buf, typeof(TDelegate));
	}
