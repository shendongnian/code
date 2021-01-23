    using System;
    using  System.Runtime.InteropServices;
    
    class App
    {
    
    [DllImportAttribute("KERNEL32.DLL", EntryPoint="MoveFileW",SetLastError=true,CharSet=CharSet.Unicode, ExactSpelling=true,
            CallingConvention=CallingConvention.StdCall)]
    public static extern bool MoveFile(String src, String dst);
    
    static void Main()
     {
       MoveFile("import.cs","D:\\aa.cs");
     }
    }
