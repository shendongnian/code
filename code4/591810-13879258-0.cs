    /// <summary>Simple class to allow creation and destruction of Consoles.</summary>
	public static class ConsoleManager
	{
        #region public static Methods
        /// <summary>
        /// Creates a console output window, if one doesn't already exist.
        /// This window will receive all outputs from System.Console.Write()
        /// </summary>
        /// <returns>
        /// 0 if successful, else the Windows API error code from Marshal.GetLastWin32Error()
        /// </returns>
        /// <remarks>See the AllocConsole() function in the Windows API for full details.</remarks>
        public static int Create()
        {
            if (AllocConsole())
            {
                return 0;
            }
            else
            {
                return Marshal.GetLastWin32Error();
            }
        }
        /// <summary>
        /// Destroys the console window, if it exists.
        /// </summary>
        /// <returns>
        /// 0 if successful, else the Windows API error code from Marshal.GetLastWin32Error()
        /// </returns>
        /// <remarks>See the FreeConsole() function in the Windows API for full details.</remarks>
        public static int Destroy()
        {
            if (FreeConsole())
            {
                return 0;
            }
            else
            {
                return Marshal.GetLastWin32Error();
            }
        }
        #endregion  // public static Methods
        #region Private PInvokes
        [SuppressMessage( "Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage" ), SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll",SetLastError=true)]
        [return: MarshalAs( UnmanagedType.Bool )]
        static extern bool AllocConsole();
        [SuppressMessage( "Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage" ), SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll",SetLastError=true)]
        [return: MarshalAs( UnmanagedType.Bool )]
        static extern bool FreeConsole();
        #endregion  // Private PInvokes
	}
