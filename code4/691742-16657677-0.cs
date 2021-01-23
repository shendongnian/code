	[System.Runtime.InteropServices.DllImport("wininet.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
	public static extern bool InternetSetOption(int hInternet, int dwOption, out int lpBuffer, int dwBufferLength);
	private static  void SuppressWininetBehavior()
	{
		/* SOURCE: http://msdn.microsoft.com/en-us/library/windows/desktop/aa385328%28v=vs.85%29.aspx
			* INTERNET_OPTION_SUPPRESS_BEHAVIOR (81):
			*      A general purpose option that is used to suppress behaviors on a process-wide basis. 
			*      The lpBuffer parameter of the function must be a pointer to a DWORD containing the specific behavior to suppress. 
			*      This option cannot be queried with InternetQueryOption. 
			*      
			* INTERNET_SUPPRESS_COOKIE_PERSIST (3):
			*      Suppresses the persistence of cookies, even if the server has specified them as persistent.
			*      Version:  Requires Internet Explorer 8.0 or later.
			*/
		int option = 3 /* INTERNET_SUPPRESS_COOKIE_PERSIST*/;
		//int* optionPtr = &option;
	   
		bool success = InternetSetOption(0, 81/*INTERNET_OPTION_SUPPRESS_BEHAVIOR*/, out option, sizeof(Int32));
		if (!success)
		{
		//	MessageBox.Show("Something went wrong !>?");
		}
	}
