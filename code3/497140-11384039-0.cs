        /// <summary>
        /// LaunchProcess As User Overloaded for Window Mode 
        /// </summary>
        /// <param name="cmdLine"></param>
        /// <param name="token"></param>
        /// <param name="envBlock"></param>
        /// <param name="WindowMode"></param>
        /// <returns></returns>
        private static bool LaunchProcessAsUser(string cmdLine, IntPtr token, IntPtr envBlock,uint WindowMode)
        {
            bool result = false;
            PROCESS_INFORMATION pi = new PROCESS_INFORMATION();
            SECURITY_ATTRIBUTES saProcess = new SECURITY_ATTRIBUTES();
            SECURITY_ATTRIBUTES saThread = new SECURITY_ATTRIBUTES();
            saProcess.nLength = (uint)Marshal.SizeOf(saProcess);
            saThread.nLength = (uint)Marshal.SizeOf(saThread);
            STARTUPINFO si = new STARTUPINFO();
            si.cb = (uint)Marshal.SizeOf(si);
            
            //if this member is NULL, the new process inherits the desktop
            //and window station of its parent process. If this member is
            //an empty string, the process does not inherit the desktop and
            //window station of its parent process; instead, the system
            //determines if a new desktop and window station need to be created.
            //If the impersonated user already has a desktop, the system uses the
            //existing desktop.
            si.lpDesktop = @"WinSta0\Default"; //Default Vista/7 Desktop Session
            si.dwFlags = STARTF_USESHOWWINDOW | STARTF_FORCEONFEEDBACK;
            //Check the Startup Mode of the Process 
            if (WindowMode == 1)
                si.wShowWindow = SW_SHOW;
            else if (WindowMode == 2)
            { //Do Nothing
            }
            else if (WindowMode == 3)
                si.wShowWindow = 0; //Hide Window 
            else if (WindowMode == 4)
                si.wShowWindow = 3; //Maximize Window
            else if (WindowMode == 5)
                si.wShowWindow = 6; //Minimize Window
            else
                si.wShowWindow = SW_SHOW;
            //Set other si properties as required.
            result = CreateProcessAsUser(
            token,
            null,
            cmdLine,
            ref saProcess,
            ref saThread,
            false,
            CREATE_UNICODE_ENVIRONMENT,
            envBlock,
            null,
            ref si,
            out pi);
            if (result == false)
            {
                int error = Marshal.GetLastWin32Error();
                string message = String.Format("CreateProcessAsUser Error: {0}", error);
                Debug.WriteLine(message);
            }
            return result;
        }
