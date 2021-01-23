    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace WindowsFormsApplication1
    {
        public class Class1
        {
            public struct Buffer
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public StringBuilder pData;
    
                public uint length;
            }
    
            [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
            static extern int LoadLibrary(string lpLibFileName);
    
            [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
            static extern IntPtr GetProcAddress(int hModule, string lpProcName);
    
            [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
            static extern bool FreeLibrary(int hModule);
    
            [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            internal delegate IntPtr SendReceive(
                uint deviceIndex,
                ref Buffer pReq,
                ref Buffer pResp,
                uint pReceivedLen,
                uint pStatus);
    
            public void ExecuteExternalDllFunction()
            {
                int dll = 0;
    
                try
                {
                    dll = LoadLibrary(@"somemodule.dll");
                    IntPtr address = GetProcAddress(dll, "SendReceive");
    
                    uint deviceIndex = 0;
                    Buffer pReq = new Buffer() { length = 0, pData = new StringBuilder() };
                    Buffer pResp = new Buffer() { length = 0, pData = new StringBuilder() };
                    uint pReceivedLen = 0;
                    uint pStatus = 0;
    
                    if (address != IntPtr.Zero)
                    {
                        SendReceive sendReceive = (SendReceive)Marshal.GetDelegateForFunctionPointer(address, typeof(SendReceive));
    
                        IntPtr ret = sendReceive(deviceIndex, ref pReq, ref pResp, pReceivedLen, pStatus);
                    }
                }
                catch (Exception Ex)
                {
                    //handle exception...
                }
                finally
                {
                    if (dll > 0)
                    {
                        FreeLibrary(dll);
                    }
                }
            }
        }
    }
