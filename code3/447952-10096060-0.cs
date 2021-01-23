    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Security.Principal;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplicationTest
    {
        class Program
        {
            static uint TOKEN_QUERY = 0x0008;
    
            [DllImport("advapi32.dll", SetLastError = true)]
            static extern bool OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool CloseHandle(IntPtr hObject);
    
    
            static void Main(string[] args)
            {
                foreach (Process p in Process.GetProcesses())
                {
                    IntPtr TokenHandle = IntPtr.Zero;
                    try
                    {
                        OpenProcessToken(p.Handle, TOKEN_QUERY, out TokenHandle);
                        WindowsIdentity WinIdent = new WindowsIdentity(TokenHandle);
                        Console.WriteLine("Pid {0} Name {1} Owner {2}", p.Handle, p.ProcessName, WinIdent.Name);
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("{0} in {1}", Ex.Message, p.ProcessName);
                    }
                    finally
                    {
                        if (TokenHandle != IntPtr.Zero) { CloseHandle(TokenHandle); }
                    }
                }
                Console.ReadKey();
            }
        }
    }
