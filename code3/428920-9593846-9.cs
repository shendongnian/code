	public static int EntryPoint( string interfaceName )
	{
		IntPtr pFunc = IntPtr.Zero;
		if ( interfaceName == "SomeMethod" )
		{
			Delegate myFuncDelegate = new VoidDelegate( SomeMethod );
			gcDelegateHandle = GCHandle.Alloc( myFuncDelegate );
			pFunc = Marshal.GetFunctionPointerForDelegate( myFuncDelegate );
		}
		return (int)pFunc.ToInt32();
	}
