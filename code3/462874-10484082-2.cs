      var fstream = sw.BaseStream as System.IO.FileStream;
      if (fstream != null)
        Console.WriteLine(GetAbsolutePathByHandle(fstream.SafeFileHandle));
    [DllImport("ntdll.dll", CharSet = CharSet.Auto)]
    private static extern int NtQueryObject(SafeFileHandle handle, int objectInformationClass, IntPtr buffer,  int StructSize, out int returnLength);
    static string GetAbsolutePathByHandle(SafeFileHandle handle)
    {
      var size = 1024;
      var buffer = Marshal.AllocCoTaskMem(size);
      try
      {
        int retSize;
        var res = NtQueryObject(handle, 1, buffer, size, out retSize);
        if (res == -1073741820)
        {
          Marshal.FreeCoTaskMem(buffer);
          size = retSize;
          Marshal.AllocCoTaskMem(size);
          res = NtQueryObject(handle, 1, buffer, size, out retSize);
        }
        if (res != 0)
          throw new Exception(res.ToString());
        var builder = new StringBuilder();
        for (int i = 4 + (Environment.Is64BitProcess ? 12 : 4); i < retSize - 2; i += 2)
        {
          builder.Append((char)Marshal.ReadInt16(buffer, i));
        }
        return builder.ToString();
      }
      finally
      {
        Marshal.FreeCoTaskMem(buffer);
      }
    }
