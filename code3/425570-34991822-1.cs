    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetProcessName(int pid)
    {
          var processHandle = OpenProcess(0x0400 | 0x0010, false, pid);
    
          if (processHandle == IntPtr.Zero)
          {
              return null;
          }
    
          const int lengthSb = 4000;
    
          var sb = new StringBuilder(lengthSb);
    
          string result = null;
                
          if (GetModuleFileNameEx(processHandle, IntPtr.Zero, sb, lengthSb) > 0)
          {
              result = Path.GetFileName(sb.ToString());
          }
    
          CloseHandle(processHandle);
    
          return result;
    }
