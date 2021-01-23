    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetProcessTimes(IntPtr hProcess, out System.Runtime.InteropServices.ComTypes.FILETIME
    	lpCreationTime, out System.Runtime.InteropServices.ComTypes.FILETIME lpExitTime, out System.Runtime.InteropServices.ComTypes.FILETIME lpKernelTime,
    	out System.Runtime.InteropServices.ComTypes.FILETIME lpUserTime);
    
    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.U4)]
    static extern UInt32 GetTickCount();
    
    static bool gbSetOldData = false;
    static UInt32 gmsOldTickCount = 0;
    static ulong gnsOldKernelTime = 0;
    static ulong gnsOldUserTime = 0;
    
    public static double getCPUUsageForProcess(int nProcID = 0)
    {
    	//Get CPU usage for the process in with ID in 'nProcID'
    	//'nProcID' = process ID, or 0 for the current process
    	//RETURN:
    	//		= CPU usage: [0.0 - 1.0]
    	//		= Negative if error
    	double fCPUUsage = 0.0;
    	try
    	{
    		IntPtr hProcess = nProcID != 0 ? Process.GetProcessById(nProcID).Handle : Process.GetCurrentProcess().Handle;
    
    		System.Runtime.InteropServices.ComTypes.FILETIME ftCreated, ftExit, ftKernel, ftUser;
    		if (GetProcessTimes(hProcess, out ftCreated, out ftExit, out ftKernel, out ftUser))
    		{
    			UInt32 dwmsNewTickCount = GetTickCount();
    
    			ulong nsNewKernelTime = (ulong)ftKernel.dwHighDateTime;
    			nsNewKernelTime <<= 32;
    			nsNewKernelTime |= (ulong)(uint)ftKernel.dwLowDateTime;
    
    			ulong nsNewUserTime = (ulong)ftUser.dwHighDateTime;
    			nsNewUserTime <<= 32;
    			nsNewUserTime |= (ulong)(uint)ftUser.dwLowDateTime;
    
    			if (gbSetOldData)
    			{
    				//Adjust from 100-nanosecond intervals to milliseconds
    				//100-nanosecond intervals = 100 * 10^-9 = 10^-7
    				//1ms = 10^-3
    				fCPUUsage = (double)((nsNewKernelTime - gnsOldKernelTime) + (nsNewUserTime - gnsOldUserTime)) /
    					(double)((dwmsNewTickCount - gmsOldTickCount) * 10000);
    
    				//Account for multiprocessor architecture
    				fCPUUsage /= Environment.ProcessorCount;
    
    				//In case timer API report is inaccurate
    				if (fCPUUsage > 1.0)
    					fCPUUsage = 1.0;
    			}
    
    			//Remember data
    			gnsOldKernelTime = nsNewKernelTime;
    			gnsOldUserTime = nsNewUserTime;
    			gmsOldTickCount = dwmsNewTickCount;
    			gbSetOldData = true;
    		}
    	}
    	catch
    	{
    		//Failed
    		fCPUUsage = -1.0;
    	}
    
    	return fCPUUsage;
    }
