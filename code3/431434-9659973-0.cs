	class WinRadioWrapper
	{
		public delegate void CallbackFunc( IntPtr pData );
		[DllImport( "WRG305API.dll" )]
		public static extern bool CodecStart( int hRadio, CallbackFunc func, IntPtr CallbackTarget );
		public bool CodecStartTest(int hRadio)
		{
			bool bStarted = CodecStart( hRadio, MyCallbackFunc, IntPtr.Zero );
			return bStarted;
		}
		// Note: this method will be called from a different thread!
		static void MyCallbackFunc( IntPtr pData )
		{
			// Sophisticated work goes here...
		}
	}
