	namespace CSharpCode
	{
		delegate void VoidDelegate();
		static public class COMInterfaceClass
		{
			[DllImport( "SharedMem.dll" )]
			static extern bool SetSharedMem( Int64 value );
			static GCHandle gcDelegateHandle;
			public static int EntryPoint(string ignored)
			{
				IntPtr pFunc = IntPtr.Zero;
				Delegate myFuncDelegate = new VoidDelegate( SomeMethod );
				gcDelegateHandle = GCHandle.Alloc( myFuncDelegate );
				pFunc = Marshal.GetFunctionPointerForDelegate( myFuncDelegate );
				bool bSetOK = SetSharedMem( pFunc.ToInt64() );
				return bSetOK ? 1 : 0;
			}
			public static void SomeMethod()
			{
				MessageBox.Show( "Hello from C# SomeMethod!" );
				gcDelegateHandle.Free();
			}
		}
	}
