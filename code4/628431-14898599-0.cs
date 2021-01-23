    		// ******************************************************************
		private const int GWL_HWNDPARENT = -8; // Owner --> not the parent
		[DllImport("user32.dll")]
		static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
		// ******************************************************************
		public static void SetOwnerWindow(Window owned, IntPtr intPtrOwner)
		{
			try
			{
				IntPtr windowHandleOwned = new WindowInteropHelper(owned).Handle;
				if (windowHandleOwned != IntPtr.Zero && intPtrOwner != IntPtr.Zero)
				{
					SetWindowLong(windowHandleOwned, GWL_HWNDPARENT, intPtrOwner.ToInt32());
				}
			}
			catch (Exception ex)
			{
				Debug.Print(ex.Message);
			}
		}
		// ******************************************************************
