	[StructLayout(LayoutKind.Explicit)]
	public struct Data
	{
		[FieldOffset(0)]
		public IntPtr NativeData;
		[FieldOffset(0)]
		public GCHandle Handle;
	}
	Data data = ...;
	((YourClass)data.Handle.Target).Blah();
