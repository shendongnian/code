    [DllImport(OpenAL.Name, EntryPoint = "alGetString")]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OpenALStringMarshaler))]
	public static extern string GetString(int name);
    internal class OpenALStringMarshaler : ICustomMarshaler
	{
		#region ICustomMarshaler Members
		public void CleanUpManagedData(object ManagedObj) { }
		public void CleanUpNativeData(IntPtr pNativeData) { }
		public int GetNativeDataSize()
			=> -1;
		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			throw new NotSupportedException();
		}
		public object MarshalNativeToManaged(IntPtr pNativeData)
			=> Marshal.PtrToStringAnsi(pNativeData);
		#endregion
		public static ICustomMarshaler GetInstance(string cookie)
		{
			if (cookie == null)
			{
				throw new ArgumentNullException(nameof(cookie));
			}
			var result = new OpenALStringMarshaler();
			return result;
		}
	}
