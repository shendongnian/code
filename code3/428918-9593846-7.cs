	namespace CSharpCode
	{
		delegate void VoidDelegate();
		public class COMInterfaceClass
		{
			static GCHandle gcDelegateHandle;
			public static int EntryPoint(string ignored)
			{
				IntPtr pFunc = IntPtr.Zero;
				Delegate myFuncDelegate = new VoidDelegate( SomeMethod );
				gcDelegateHandle = GCHandle.Alloc( myFuncDelegate );
				pFunc = Marshal.GetFunctionPointerForDelegate( myFuncDelegate );
				return (int)pFunc.ToInt32();
			}
			public static void SomeMethod()
			{
				MessageBox.Show( "Hello from C# SomeMethod!" );
				gcDelegateHandle.Free();
			}
		}
	}
